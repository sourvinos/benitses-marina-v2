using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Sales {

    public static class SaleDomainToListVM {

        public static IEnumerable<SaleListVM> Read(IQueryable<Sale> sales) {
            return [.. sales.Select(x => new SaleListVM {
                InvoiceId = x.InvoiceId,
                ReservationId = x.ReservationId,
                Date = DateHelpers.DateToISOString(x.Date),
                Customer = new SimpleEntity {
                    Id = x.Customer.Id,
                    Description = x.Customer.Description,
                },
                DocumentType = new SimpleEntity{
                    Id = x.DocumentType.Id,
                    Description = x.DocumentType.Description
                },
                InvoceNo = x.InvoiceNo,
                GrossAmount = x.GrossAmount,
                IsEmailPending = x.IsEmailPending,
                IsEmailSent = x.IsEmailSent
            })];
        }

    }

}