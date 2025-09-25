namespace API.Features.Boats.Admin {

    public class BoatFishingLicenceWriteDto {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string IssuingAuthority { get; set; }
        public string LicenceNo { get; set; }
        public string? ExpireDate { get; set; }

    }

}