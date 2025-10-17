using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Sales {

    public static class SaleMappingRead {

        public static SaleReadDto Read(Sale sale) {
            return new SaleReadDto {
                SaleId = sale.SaleId.ToString(),
                DiscriminatorId = sale.DiscriminatorId,
                Date = DateHelpers.DateToISOString(sale.Date),
                Customer = new SimpleEntity {
                    Id = sale.Customer.Id,
                    Description = sale.Customer.Description
                },
                DocumentType = new SimpleEntity {
                    Id = sale.DocumentType.Id,
                    Description = sale.DocumentType.Description
                },
                PaymentMethod = new SimpleEntity {
                    Id = sale.PaymentMethod.Id,
                    Description = sale.PaymentMethod.Description
                },
                InvoiceNo = sale.InvoiceNo,
                NetAmount = sale.NetAmount,
                VatAmount = sale.VatAmount,
                GrossAmount = sale.GrossAmount,
                Items = [.. sale.Items.Select(x => new SaleItemReadDto {
                    Id = x.Id,
                    SaleId = x.SaleId.ToString(),
                    Item = new SimpleEntity{
                        Id = x.Item.Id,
                        Description = x.Item.Description
                    },
                    Qty = x.Qty,
                    UnitPrice = x.UnitPrice,
                    NetAmountPreDiscount = x.NetAmountPreDiscount,
                    DiscountPercent = x.DiscountPercent,
                    DiscountAmount = x.DiscountAmount,
                    NetAmountPostDiscount = x.NetAmountPostDiscount,
                    VatPercent = x.VatPercent,
                    VatAmount = x.VatAmount,
                    GrossAmount = x.GrossAmount
                })],
                IsEmailPending = sale.IsEmailPending,
                IsEmailSent = sale.IsEmailSent,
                IsCancelled = sale.IsCancelled,
                PostAt = sale.PostAt,
                PostUser = sale.PostUser,
                PutAt = sale.PutAt,
                PutUser = sale.PutUser
            };
        }

    }

}