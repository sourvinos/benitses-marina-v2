using API.Infrastructure.Classes;

namespace API.Features.Reservations {

    public class ReservationBerthReadDto {

        public int Id { get; set; }
        public string ReservationId { get; set; }
        public SimpleEntity Berth { get; set; }

    }

}