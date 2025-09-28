using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.BoatUsages {

    [Route("api/[controller]")]
    public class BoatUsagesController(IBoatUsageRepository repo, IBoatUsageValidation validation) : ControllerBase {

        #region variables

        private readonly IBoatUsageRepository repo = repo;
        private readonly IBoatUsageValidation validation = validation;

        #endregion

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IEnumerable<BoatUsageListVM> Get() {
            return repo.Get();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public IEnumerable<BoatUsageBrowserVM> GetForBrowser() {
            return  repo.GetForBrowser();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await repo.GetByIdAsync(id);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = BoatUsageMappings.DomainToDto(x),
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
        public ResponseWithBody Post([FromBody] BoatUsageWriteDto boatUsage) {
            var x = validation.IsValid(null, boatUsage);
            if (x == 200) {
                var z = repo.Create((BoatUsage)repo.AttachMetadataToPostDto(BoatUsageMappings.DtoToDomail(boatUsage)));
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
        public async Task<ResponseWithBody> Put([FromBody] BoatUsageWriteDto boatUsage) {
            var x = await repo.GetByIdAsync(boatUsage.Id);
            if (x != null) {
                var z = validation.IsValid(x, boatUsage);
                if (z == 200) {
                    var i = repo.Update((BoatUsage)repo.AttachMetadataToPostDto(BoatUsageMappings.DtoToDomail(boatUsage)));
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