using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Extensions;
using API.Infrastructure.Helpers;
using API.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Reservations {

    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase {

        #region variables

        private readonly IReservationRepository reservationRepo;
        private readonly IReservationValidation reservationValidation;

        #endregion

        public ReservationsController(IReservationRepository reservationRepo, IReservationValidation reservationValidation) {
            this.reservationRepo = reservationRepo;
            this.reservationValidation = reservationValidation;
        }

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            return await reservationRepo.GetAsync();
        }

        [HttpGet("{reservationId}")]
        [Authorize(Roles = "user, admin")]
        public async Task<ResponseWithBody> GetByIdAsync(string reservationId) {
            var x = await reservationRepo.GetByIdAsync(reservationId);
            if (x != null) {
                return new ResponseWithBody {
                    Code = 200,
                    Icon = Icons.Info.ToString(),
                    Message = ApiMessages.OK(),
                    Body = ReservationMappingDomainToDto.DomainToDto(x)
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
        public async Task<Response> PostAsync([FromBody] ReservationWriteDto reservation) {
            var z = reservationValidation.IsValidAsync(null, reservation);
            if (await z == 200) {
                var x = reservationRepo.Create((Reservation)reservationRepo.AttachMetadataToPostDto(ReservationMappingDtoToDomain.DtoToDomain(reservation)));
                return new Response {
                    Code = 200,
                    Icon = Icons.Success.ToString(),
                    Id = x.ReservationId.ToString(),
                    Message = ApiMessages.OK()
                };
            } else {
                throw new CustomException() {
                    ResponseCode = await z
                };
            }
        }

    }

}