using System;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace API.Infrastructure.Middleware {

    public class ResponseMiddleware : IMiddleware {

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<UserExtended> userManager;

        public ResponseMiddleware(IHttpContextAccessor httpContextAccessor, UserManager<UserExtended> userManager) {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next) {
            try {
                await next(httpContext);
            }
            catch (CustomException exception) {
                await CreateCustomErrorResponse(httpContext, exception);
            }
            catch (DbUpdateConcurrencyException) {
                await CreateConcurrencyErrorResponse(httpContext);
            }
            catch (Exception exception) {
                LogError(exception, httpContextAccessor, userManager);
                await CreateServerErrorResponse(httpContext, exception);
            }
        }

        private static Task CreateCustomErrorResponse(HttpContext httpContext, CustomException e) {
            httpContext.Response.StatusCode = e.ResponseCode;
            httpContext.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new ErrorResponse {
                Code = e.ResponseCode,
                Icon = Icons.Error.ToString(),
                Message = GetErrorMessage(e.ResponseCode)
            });
            return httpContext.Response.WriteAsync(result);
        }

        private static Task CreateConcurrencyErrorResponse(HttpContext httpContext) {
            httpContext.Response.StatusCode = 415;
            httpContext.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new ErrorResponse {
                Code = 415,
                Icon = Icons.Error.ToString(),
                Message = GetErrorMessage(httpContext.Response.StatusCode)
            });
            return httpContext.Response.WriteAsync(result);
        }

        private static Task CreateServerErrorResponse(HttpContext httpContext, Exception e) {
            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new ErrorResponse {
                Code = 500,
                Icon = Icons.Error.ToString(),
                Message = e.Message
            });
            return httpContext.Response.WriteAsync(result);
        }

        private static string GetErrorMessage(int httpResponseCode) {
            return httpResponseCode switch {
                401 => ApiMessages.AuthenticationFailed(),
                404 => ApiMessages.RecordNotFound(),
                415 => ApiMessages.ConcurrencyError(),
                450 => ApiMessages.InvalidBoatUsage(),
                451 => ApiMessages.InvalidHullType(),
                452 => ApiMessages.InvalidBoat(),
                491 => ApiMessages.RecordInUse(),
                490 => ApiMessages.NotOwnRecord(),
                492 => ApiMessages.InvalidNewUser(),
                _ => ApiMessages.UnknownError(),
            };
        }

        private static void LogError(Exception exception, IHttpContextAccessor httpContextAccessor, UserManager<UserExtended> userManager) {
            Log.Error("USER {userId} | MESSAGE {message}", Identity.GetConnectedUserDetails(userManager, Identity.GetConnectedUserId(httpContextAccessor)).UserName, exception.Message);
        }

    }

}