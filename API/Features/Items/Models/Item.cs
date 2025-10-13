using API.Features.HullTypes;
using API.Features.PeriodTypes;
using API.Features.SeasonTypes;
using API.Infrastructure.Interfaces;

namespace API.Features.Items {

    public class Item : IMetadata {

        public int Id { get; set; }
        public int HullTypeId { get; set; }
        public int PeriodTypeId { get; set; }
        public int SeasonTypeId { get; set; }
        public HullType HullType { get; set; }
        public PeriodType PeriodType { get; set; }
        public SeasonType SeasonType { get; set; }
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
        public string PostAt { get; set; }
        public string PostUser { get; set; }
        public string PutAt { get; set; }
        public string PutUser { get; set; }

    }

}