using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Boats.Admin {

    [Route("api/[controller]")]
    public class BoatsController(IBoatRepository repo, IBoatValidation validation) : ControllerBase {

        #region variables

        private readonly IBoatRepository repo = repo;
        private readonly IBoatValidation validation = validation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<BoatListVM> Get() {
            return repo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<BoatBrowserVM> GetForBrowser() {
            return repo.GetForBrowser();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await repo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = BoatMappingDomainToDto.DomainToDto(x),
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
        public ResponseWithBody Post([FromBody] BoatWriteDto boat) {
            var x = validation.IsValidAsync(null, boat).Result;
            if (x == 200) {
                var z = repo.Create((Boat)repo.AttachMetadataToPutDto(BoatMappingDtoPostToDomain.DtoPostToDomain(boat)));
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
        public async Task<ResponseWithBody> Put([FromBody] BoatWriteDto boat) {
            var x = await repo.GetByIdAsync(boat.Id, true);
            if (x != null) {
                var z = validation.IsValidAsync(x, boat).Result;
                if (z == 200) {
                    var i = repo.Update((Boat)repo.AttachMetadataToPutDto(x, BoatMappingDtoPutToDomain.DtoPutToDomain(x, boat)));
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
            var x = await repo.GetByIdAsync(id, true);
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