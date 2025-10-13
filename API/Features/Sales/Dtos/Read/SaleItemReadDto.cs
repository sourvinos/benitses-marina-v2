using API.Infrastructure.Classes;

namespace API.Features.Sales {

    public class SaleItemReadDto {

        public int Id { get; set; }
        public string SaleId { get; set; }
        public SimpleEntity Item { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitItem { get; set; }
        public decimal NetAmountPreDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmountPostDiscount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }

    }

}