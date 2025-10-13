using API.Infrastructure.Classes;

namespace API.Features.Items {

    public class ItemListVM {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public SimpleEntity HullType { get; set; }
        public SimpleEntity PeriodType { get; set; }
        public SimpleEntity SeasonType { get; set; }
        public bool IsIndividual { get; set; }
        public decimal Length { get; set; }
        public string NetAmount { get; set; }
        public string VatPercent { get; set; }
        public string VatAmount { get; set; }
        public string GrossAmount { get; set; }

    }

}