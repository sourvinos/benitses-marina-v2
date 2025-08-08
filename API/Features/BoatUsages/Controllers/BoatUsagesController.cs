using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.BoatUsages {

    [Route("api/[controller]")]
    public class BoatUsagesController : ControllerBase {

        #region variables

        private readonly IBoatUsageRepository BoatUsageRepo;
        private readonly IBoatUsageValidation BoatUsageValidation;

        #endregion

        public BoatUsagesController(IBoatUsageRepository BoatUsageRepo, IBoatUsageValidation BoatUsageValidation) {
            this.BoatUsageRepo = BoatUsageRepo;
            this.BoatUsageValidation = BoatUsageValidation;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<BoatUsageListVM>> GetAsync() {
            return await BoatUsageRepo.GetAsync();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<BoatUsageBrowserVM>> GetForBrowserAsync() {
            return await BoatUsageRepo.GetForBrowserAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await BoatUsageRepo.GetByIdAsync(id);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = BoatUsageMappings.DomainToDto(x)
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
        public ResponseWithBody Post([FromBody] BoatUsageWriteDto BoatUsage) {
            var x = BoatUsageValidation.IsValid(null, BoatUsage);
            if (x == 200) {
                var z = BoatUsageRepo.Create((BoatUsage)BoatUsageRepo.AttachMetadataToPostDto(BoatUsageMappings.DtoToDomail(BoatUsage)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = BoatUsageRepo.GetByIdForBrowserAsync(z.Id).Result,
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
        public async Task<ResponseWithBody> Put([FromBody] BoatUsageWriteDto BoatUsage) {
            var x = await BoatUsageRepo.GetByIdAsync(BoatUsage.Id);
            if (x != null) {
                var z = BoatUsageValidation.IsValid(x, BoatUsage);
                if (z == 200) {
                    BoatUsageRepo.Update((BoatUsage)BoatUsageRepo.AttachMetadataToPostDto(BoatUsageMappings.DtoToDomail(BoatUsage)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = BoatUsageRepo.GetByIdForBrowserAsync(BoatUsage.Id).Result,
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
            var x = await BoatUsageRepo.GetByIdAsync(id);
            if (x != null) {
                BoatUsageRepo.Delete(x);
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