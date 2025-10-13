using System;
using API.Features.Items;

namespace API.Features.Sales {

    public class SaleItem {

        public int Id { get; set; }
        public Guid SaleId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal NetAmountPreDiscount { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetAmountPostDiscount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossAmount { get; set; }

    }

}