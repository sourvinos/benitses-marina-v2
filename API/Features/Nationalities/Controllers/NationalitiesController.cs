using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Nationalities {

    [Route("api/[controller]")]
    public class NationalitiesController(INationalityRepository repo, INationalityValidation validation) : ControllerBase {

        #region variables

        private readonly INationalityRepository repo = repo;
        private readonly INationalityValidation validation = validation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<NationalityListVM> Get() {
            return repo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<NationalityBrowserListVM> GetForBrowser() {
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
                    Body = NationalityMappings.DomainToDto(x),
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
        public ResponseWithBody Post([FromBody] NationalityWriteDto nationality) {
            var x = validation.IsValid(null, nationality);
            if (x == 200) {
                var z = repo.Create((Nationality)repo.AttachMetadataToPutDto(NationalityMappings.DtoToDomail(nationality)));
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
        public async Task<ResponseWithBody> Put([FromBody] NationalityWriteDto nationality) {
            var x = await repo.GetByIdAsync(nationality.Id);
            if (x != null) {
                var z = validation.IsValid(x, nationality);
                if (z == 200) {
                    var i = repo.Update((Nationality)repo.AttachMetadataToPutDto(NationalityMappings.DtoToDomail(nationality)));
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