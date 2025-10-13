using API.Infrastructure.Classes;
using API.Infrastructure.Interfaces;

namespace API.Features.Items {

    public class ItemReadDto : IMetadata {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string EnglishDescription { get; set; }
        public SimpleEntity HullType { get; set; }
        public SimpleEntity PeriodType { get; set; }
        public SimpleEntity SeasonType { get; set; }
        public bool IsIndividual { get; set; }
        public decimal Length { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}