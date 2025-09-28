using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.HullTypes {

    [Route("api/[controller]")]
    public class HullTypesController(IHullTypeRepository repo, IHullTypeValidation validation) : ControllerBase {

        #region variables

        private readonly IHullTypeRepository repo = repo;
        private readonly IHullTypeValidation validation = validation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<HullTypeListVM> Get() {
            return repo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<HullTypeBrowserVM> GetForBrowser() {
            return repo.GetForBrowser();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await repo.GetByIdAsync(id);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = HullTypeMappings.DomainToDto(x),
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public ResponseWithBody Post([FromBody] HullTypeWriteDto hullType) {
            var x = validation.IsValid(null, hullType);
            if (x == 200) {
                var z = repo.Create((HullType)repo.AttachMetadataToPostDto(HullTypeMappings.DtoToDomail(hullType)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = z,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = x
                };
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> Put([FromBody] HullTypeWriteDto hullType) {
            var x = await repo.GetByIdAsync(hullType.Id);
            if (x != null) {
                var z = validation.IsValid(x, hullType);
                if (z == 200) {
                    var i = repo.Update((HullType)repo.AttachMetadataToPostDto(HullTypeMappings.DtoToDomail(hullType)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = i,
                        Message = ApiMessages.OK()
                    };
                } else {
                    throw new CustomException() {
                        ResponseCode = z
                    };
                }
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> Delete([FromRoute] int id) {
            var x = await repo.GetByIdAsync(id);
            if (x != null) {
                repo.Delete(x);
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = x,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

    }

}