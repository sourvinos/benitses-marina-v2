using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Infrastructure.Users {

    [Route("api/[controller]")]
    public class UsersController(IHttpContextAccessor httpContext, IUserRepository userRepo, IUserValidation<IUser> userValidation) : ControllerBase {

        #region variables

        private readonly IHttpContextAccessor httpContext = httpContext;
        private readonly IUserRepository userRepo = userRepo;
        private readonly IUserValidation<IUser> userValidation = userValidation;

        #endregion

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
                if (Identity.IsUserAdmin(httpContext) || userValidation.IsUserOwner(x.Id)) {
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Info.ToString(),
                        Body = UserMappings.DomainToDto(x),
                        Message = ApiMessages.OK()
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
                Body = x,
                Message = ApiMessages.OK(),
            };
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> PostAsync([FromBody] UserNewDto user) {
            var x = await userRepo.CreateAsync((UserExtended)userRepo.AttachMetadataToPostDto(UserMappings.DtoToDomail(user)), userRepo.CreateTemporaryPassword());
            return new ResponseWithBody {
                Code = x.Succeeded ? 200 : 492,
                Icon = x.Succeeded ? Icons.Success.ToString() : Icons.Error.ToString(),
                Body = x,
                Message = x.Succeeded ? ApiMessages.OK() : ApiMessages.InvalidNewUser()
            };
        }

        [HttpPut]
        [Authorize(Roles = "user, admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> PutAsync([FromBody] UserUpdateDto userToUpdate) {
            var user = await userRepo.GetByIdAsync(userToUpdate.Id);
            if (user != null) {
                var z = userValidation.IsValid(userToUpdate);
                if (z == 200) {
                    if (Identity.IsUserAdmin(httpContext)) {
                        return await UpdateAdmin(user, userToUpdate);
                    } else {
                        if (userValidation.IsUserOwner(user.Id)) {
                            return await UpdateSimpleUser(user, userToUpdate);
                        } else {
                            throw new CustomException() {
                                ResponseCode = 490
                            };
                        }
                    }
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

        private async Task<ResponseWithBody> UpdateAdmin(UserExtended user, UserUpdateDto userToUpdate) {
            if (await userRepo.UpdateAdminAsync(user, userToUpdate)) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = userToUpdate,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 492
                };
            }
        }

        private async Task<ResponseWithBody> UpdateSimpleUser(UserExtended user, UserUpdateDto userToUpdate) {
            if (await userRepo.UpdateSimpleUserAsync(user, userToUpdate)) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = userToUpdate,
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