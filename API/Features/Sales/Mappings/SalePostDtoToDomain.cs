using System.Linq;
using API.Infrastructure.Helpers;

namespace API.Features.Sales {

    public static class SalePostDtoToDomain {

        public static Sale Write(SaleWriteDto sale) {
            return new Sale {
                SaleId = sale.SaleId,
                ReservationId = sale.ReservationId,
                Date = DateHelpers.StringToDate(sale.Date),
                InvoiceNo = sale.InvoiceNo,
                CustomerId = sale.CustomerId,
                DocumentTypeId = sale.DocumentTypeId,
                PaymentMethodId = sale.PaymentMethodId,
                NetAmount = sale.NetAmount,
                VatAmount = sale.VatAmount,
                Items = [.. sale.Items.Select(x => new SaleItem {
                    Id = x.Id,
                    SaleId = x.SaleId,
                    ItemId = x.ItemId,
                    Qty = x.Qty,
                    UnitPrice = x.UnitPrice,
                    NetAmountPreDiscount = x.NetAmountPreDiscount,
                    DiscountPercent = x.DiscountPercent,
                    DiscountAmount = x.DiscountAmount,
                    NetAmountPostDiscount = x.NetAmountPostDiscount,
                    VatPercent = x.VatPercent,
                    VatAmount = x.VatAmount
                })],
                PostAt = sale.PostAt,
                PostUser = sale.PostUser,
                PutAt = sale.PutAt,
                PutUser = sale.PutUser
            };
        }

    }

}