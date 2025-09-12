using System;

namespace API.Features.Reservations {

    public class ReservationBerthWriteDto {

        public int Id { get; set; }
        public Guid ReservationId { get; set; }
        public int BerthId { get; set; }

    }

}