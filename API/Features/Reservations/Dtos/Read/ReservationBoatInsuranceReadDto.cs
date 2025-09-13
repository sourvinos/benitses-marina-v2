namespace API.Features.Reservations {

    public class ReservationBoatInsuranceReadDto {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Company { get; set; }
        public string ContractNo { get; set; }
        public string ExpireDate { get; set; }
        public bool IsExpired { get; set; }

    }

}