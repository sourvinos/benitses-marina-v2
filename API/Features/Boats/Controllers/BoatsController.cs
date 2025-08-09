using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Boats {

    [Route("api/[controller]")]
    public class BoatsController : ControllerBase {

        #region variables

        private readonly IBoatRepository boatRepo;
        private readonly IBoatValidation boatValidation;

        #endregion

        public BoatsController(IBoatRepository boatRepo, IBoatValidation BoatValidation) {
            this.boatRepo = boatRepo;
            this.boatValidation = BoatValidation;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IEnumerable<BoatListVM>> GetAsync() {
            return await boatRepo.GetAsync();
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<BoatBrowserVM>> GetForBrowserAsync() {
            return await boatRepo.GetForBrowserAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> GetByIdAsync(int id) {
            var x = await boatRepo.GetByIdAsync(id, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = BoatMappings.DomainToDto(x)
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
            var x = boatValidation.IsValidAsync(null, boat);
            if (x == 200) {
                var z = boatRepo.Create((Boat)boatRepo.AttachMetadataToPostDto(BoatMappings.DtoToDomain(boat)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = boatRepo.GetByIdForBrowserAsync(z.Id).Result,
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
            var x = await boatRepo.GetByIdAsync(boat.Id, false);
            if (x != null) {
                var z = boatValidation.IsValidAsync(x, boat);
                if (z == 200) {
                    boatRepo.Update((Boat)boatRepo.AttachMetadataToPostDto(BoatMappings.DtoToDomain(boat)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = boatRepo.GetByIdForBrowserAsync(boat.Id).Result,
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
            var x = await boatRepo.GetByIdAsync(id, false);
            if (x != null) {
                boatRepo.Delete(x);
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