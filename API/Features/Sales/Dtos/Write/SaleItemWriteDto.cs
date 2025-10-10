using System;

namespace API.Features.Sales {

    public class SaleItemWriteDto {

        public int Id { get; set; }
        public Guid SaleId { get; set; }
        public int ItemId { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetAmountPreDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmountPostDiscount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatAmount { get; set; }

    }

}