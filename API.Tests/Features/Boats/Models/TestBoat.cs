namespace Boats {

    public class TestBoat {

        public int StatusCode { get; set; }

        public int Id { get; set; }
        public int BoatUsageId { get; set; }
        public int HullTypeId { get; set; }
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
        public TestBoatInsurance Insurance { get; set; }
        public string PutAt { get; set; }

    }

}