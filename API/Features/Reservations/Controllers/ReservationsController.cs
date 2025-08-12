using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Reservations {

    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase {

        #region variables

        private readonly IReservationRepository reservationRepo;

        #endregion

        public ReservationsController(IReservationRepository reservationRepo) {
            this.reservationRepo = reservationRepo;
        }

        [HttpGet()]
        [Authorize(Roles = "user, admin")]
        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            return await reservationRepo.GetAsync();
        }

    }

}