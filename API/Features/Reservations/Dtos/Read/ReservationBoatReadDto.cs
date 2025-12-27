using API.Infrastructure.Classes;

namespace API.Features.Reservations {

    public class ReservationBoatReadDto {

        public int Id { get; set; }
        public string Description { get; set; }
        public SimpleEntity HullType { get; set; }
        public SimpleEntity Usage { get; set; }
        public SimpleEntity Nationality { get; set; }
        public ReservationBoatInsuranceReadDto Insurance { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }
        public decimal Draft { get; set; }
        public string RegistryPort { get; set; }
        public string RegistryNo { get; set; }

    }

}