using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Reservations {

    [Route("api/[controller]")]
    public class ReservationsController(IReservationRepository repo, IReservationValidation validation) : ControllerBase {

        #region variables

        private readonly IReservationRepository repo = repo;
        private readonly IReservationValidation validation = validation;

        #endregion

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            return await repo.GetAsync();
        }

        [HttpGet("{reservationId}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(string reservationId) {
            var x = await repo.GetByIdAsync(reservationId, true);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Body = ReservationMappingReadDomainToDto.ReservationReadDomainToDto(x),
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
        public async Task<ResponseWithBody> PostAsync([FromBody] ReservationWriteDto reservation) {
            var x = validation.IsValidAsync(null, reservation);
            if (await x == 200) {
                var z = repo.Create((Reservation)repo.AttachMetadataToPostDto(ReservationMappingPostDtoToDomain.ReservationPostToDomainDto(reservation)));
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Body = z,
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = await x
                };
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ServiceFilter(typeof(ModelValidationAttribute))]
        public async Task<ResponseWithBody> Put([FromBody] ReservationWriteDto reservation) {
            var x = await repo.GetByIdAsync(reservation.ReservationId.ToString(), true);
            if (x != null) {
                var z = validation.IsValidAsync(x, reservation);
                if (await z == 200) {
                    var i = repo.Update(reservation.ReservationId, (Reservation)repo.AttachMetadataToPutDto(x, ReservationMappingPutDtoToDomain.ReservationPutDtoToDomain(x, reservation)));
                    return new ResponseWithBody {
                        Code = 200,
                        Icon = Icons.Success.ToString(),
                        Body = i,
                        Message = ApiMessages.OK()
                    };
                } else {
                    throw new CustomException() {
                        ResponseCode = await z
                    };
                }
            } else {
                throw new CustomException() {
                    ResponseCode = 404
                };
            }
        }

        [HttpDelete("{reservationId}")]
        [Authorize(Roles = "admin")]
        public async Task<ResponseWithBody> Delete([FromRoute] string reservationId) {
            var x = await repo.GetByIdAsync(reservationId, true);
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