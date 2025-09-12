using System;
using API.Features.Berths;

namespace API.Features.Reservations {

    public class ReservationBerth {

        public int Id { get; set; }
        public Guid ReservationId { get; set; }
        public int BerthId { get; set; }
        public Berth Berth { get; set; }

    }

}