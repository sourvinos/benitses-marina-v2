namespace API.Features.Boats.Insurances {

    public class ExpiredInsuranceBoatVM {

        public int BoatId { get; set; }
        public string Description { get; set; }
        public bool IsAthenian { get; set; }
        public bool IsFishingBoat { get; set; }
        public string InsuranceExpireDate { get; set; }

    }

}