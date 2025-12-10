using API.Infrastructure.Classes;

namespace API.Features.Boats.Admin {

    public class BoatBrowserListVM {

        public int Id { get; set; }
        public string Description { get; set; }
        public SimpleEntity HullType { get; set; }
        public SimpleEntity Usage { get; set; }
        public BoatBrowserListInsuranceVM Insurance { get; set; }
        public string Flag { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }
        public decimal Draft { get; set; }
        public string RegistryPort { get; set; }
        public string RegistryNo { get; set; }
        public bool IsAthenian { get; set; }
        public bool IsFishingBoat { get; set; }
        public bool IsActive { get; set; }

    }

}