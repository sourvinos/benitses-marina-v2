namespace Items {

    public class TestItem {

        public int StatusCode { get; set; }

        public int Id { get; set; }
        public int HullTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public int SeasonTypeId { get; set; }
        public TestItemHullType HullType { get; set; }
        public TestItemPeriodType PeriodType { get; set; }
        public TestItemSeasonType SeasonType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }
        public decimal Length { get; set; }
        public bool IsIndividual { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public bool IsActive { get; set; }
        public string PutAt { get; set; }

    }

}