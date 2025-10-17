using System.Linq;
using API.Infrastructure.Helpers;

namespace API.Features.Sales {

    public static class SaleWrite {

        public static Sale Write(SaleWriteDto sale) {
            return new Sale {
                DiscriminatorId = sale.DiscriminatorId,
                Date = DateHelpers.GetLocalDateTime(),
                InvoiceNo = sale.InvoiceNo,
                CustomerId = sale.CustomerId,
                DocumentTypeId = sale.DocumentTypeId,
                PaymentMethodId = sale.PaymentMethodId,
                NetAmount = sale.Items.Sum(x => x.Qty * x.UnitPrice - x.DiscountAmount),
                VatAmount = sale.Items.Sum(x => (x.Qty * x.UnitPrice - x.DiscountAmount) * (x.VatPercent / 100)),
                Items = [.. sale.Items.Select(x => new SaleItem {
                    ItemId = x.ItemId,
                    Qty = x.Qty,
                    UnitPrice = x.UnitPrice,
                    NetAmountPreDiscount = x.NetAmountPreDiscount,
                    DiscountPercent = x.DiscountPercent,
                    DiscountAmount = x.DiscountAmount,
                    NetAmountPostDiscount = x.NetAmountPostDiscount,
                    VatPercent = x.VatPercent
                })],
                PostAt = sale.PostAt,
                PostUser = sale.PostUser,
                PutAt = sale.PutAt,
                PutUser = sale.PutUser
            };
        }

    }

}