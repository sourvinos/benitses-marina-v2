namespace API.Features.Boats.Admin {

    public class BoatInsuranceWriteDto {

        public int Id { get; set; }
        public int BoatId { get; set; }
        public string Company { get; set; }
        public string ContractNo { get; set; }
        public string? ExpireDate { get; set; }

    }

}