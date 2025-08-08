using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infrastructure.Users {

    [Route("api/[controller]")]
    public class UsersController : ControllerBase {

        #region variables

        private readonly IHttpContextAccessor httpContext;
        private readonly IUserRepository userRepo;

        #endregion

        public UsersController(IHttpContextAccessor httpContext, IUserRepository userRepo) {
            this.httpContext = httpContext;
            this.userRepo = userRepo;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<UserListVM>> GetAsync() {
            return await userRepo.GetAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(string id) {
            var x = await userRepo.GetByIdAsync(id);
            if (x != null) {
                if (Identity.IsUserAdmin(httpContext)) {
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Info.ToString(),
                        Message = ApiMessages.OK(),
                        Body = UserMappings.DomainToDto(x)
                    };
                } else {
                    throw new CustomException() {
                        ResponseCode = 490
                    };
                }
                ;
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpGet("getByEmail/{email}")]
        [AllowAnonymous]
        public async Task<ResponseWithBody> GetByEmailAsync(string email) {
            var x = await userRepo.GetByEmailAsync(email);
            return new ResponseWithBody {
                Code = 200,
                Icon = Icons.Info.ToString(),
                Message = ApiMessages.OK(),
                Body = x != null ? x.Id : ""
            };
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<Response> PostAsync([FromBody] UserNewDto user) {
            await userRepo.CreateAsync((UserExtended)userRepo.AttachMetadataToPostDto(UserMappings.DtoToDomail(user)), userRepo.CreateTemporaryPassword());
            return new Response {
                Code = 200,
                Icon = Icons.Success.ToString(),
                Id = null,
                Message = ApiMessages.OK()
            };
        }

        [HttpPut]
        [Authorize(Roles = "user, admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<Response> PutAsync([FromBody] UserUpdateDto userToUpdate) {
            var user = await userRepo.GetByIdAsync(userToUpdate.Id);
            if (user != null) {
                if (Identity.IsUserAdmin(httpContext)) {
                    return await UpdateAdmin(user, userToUpdate);
                } else {
                    throw new CustomException() {
                        ResponseCode = 490
                    };
                }
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        private async Task<Response> UpdateAdmin(UserExtended user, UserUpdateDto userToUpdate) {
            if (await userRepo.UpdateAdminAsync(user, userToUpdate)) {
                return new Response {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Id = null,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 492
                };
            }
        }

    }

}