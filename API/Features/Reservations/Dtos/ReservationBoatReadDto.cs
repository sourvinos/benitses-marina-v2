using API.Infrastructure.Classes;

namespace API.Features.Reservations {

    public class ReservationBoatReadDto {

        public int Id { get; set; }
        public SimpleEntity Type { get; set; }
        public string Description { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }

    }

}