using API.Features.BoatTypes;
using API.Features.BoatUsages;
using API.Infrastructure.Interfaces;

namespace API.Features.Boats {

    public class Boat : IBaseEntity, IMetadata {

        public int Id { get; set; }
        public int BoatTypeId { get; set; }
        public int BoatUsageId { get; set; }
        public string Description { get; set; }
        public string Flag { get; set; }
        public decimal Loa { get; set; }
        public decimal Beam { get; set; }
        public decimal Draft { get; set; }
        public string RegistryPort { get; set; }
        public string RegistryNo { get; set; }
        public bool IsAthenian { get; set; }
        public bool IsFishingBoat { get; set; }
        public bool IsActive { get; set; }
        public BoatType Type { get; set; }
        public BoatUsage Usage { get; set; }
        public BoatInsurance Insurance { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}