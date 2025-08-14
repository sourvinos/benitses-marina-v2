using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.HullTypes {

    [Route("api/[controller]")]
    public class HullTypesController : ControllerBase {

        #region variables

        private readonly IHullTypeRepository hullTypeRepo;
        private readonly IHullTypeValidation hullTypeValidation;

        #endregion

        public HullTypesController(IHullTypeRepository hullTypeRepo, IHullTypeValidation HullTypeValidation) {
            this.hullTypeRepo = hullTypeRepo;
            this.hullTypeValidation = HullTypeValidation;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<HullTypeListVM>> GetAsync() {
            return await hullTypeRepo.GetAsync();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<HullTypeBrowserVM>> GetForBrowserAsync() {
            return await hullTypeRepo.GetForBrowserAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await hullTypeRepo.GetByIdAsync(id);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = HullTypeMappings.DomainToDto(x)
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
            var x = hullTypeValidation.IsValid(null, hullType);
            if (x == 200) {
                var z = hullTypeRepo.Create((HullType)hullTypeRepo.AttachMetadataToPostDto(HullTypeMappings.DtoToDomail(hullType)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = hullTypeRepo.GetByIdForBrowserAsync(z.Id).Result,
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
            var x = await hullTypeRepo.GetByIdAsync(hullType.Id);
            if (x != null) {
                var z = hullTypeValidation.IsValid(x, hullType);
                if (z == 200) {
                    hullTypeRepo.Update((HullType)hullTypeRepo.AttachMetadataToPostDto(HullTypeMappings.DtoToDomail(hullType)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = hullTypeRepo.GetByIdForBrowserAsync(hullType.Id).Result,
                        Message = ApiMessages.OK(),
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
        public async Task<Response> Delete([FromRoute] int id) {
            var x = await hullTypeRepo.GetByIdAsync(id);
            if (x != null) {
                hullTypeRepo.Delete(x);
                return new Response {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Id = x.Id.ToString(),
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