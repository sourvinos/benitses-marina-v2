using API.Infrastructure.Classes;
using API.Infrastructure.Interfaces;

namespace API.Features.Boats.Admin {

    public class BoatReadDto : IBaseEntity, IMetadata {

        public int Id { get; set; }
        public SimpleEntity BoatUsage { get; set; }
        public SimpleEntity HullType { get; set; }
        public SimpleEntity Nationality { get; set; }
        public string Description { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }
        public decimal Draft { get; set; }
        public string RegistryPort { get; set; }
        public string RegistryNo { get; set; }
        public BoatFishingLicenceReadDto FishingLicence { get; set; }
        public BoatInsuranceReadDto Insurance { get; set; }
        public bool IsAthenian { get; set; }
        public bool IsFishingBoat { get; set; }
        public bool IsActive { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}