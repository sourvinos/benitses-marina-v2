namespace API.Features.Boats {

    public class BoatFishingLicenceReadDto {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string IssuingAuthority { get; set; }
        public string LicenceNo { get; set; }
        public string? ExpireDate { get; set; }

    }

}