using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace API.Features.Sales {

    public class SaleValidation(AppDbContext context, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Sale>(context, httpContext, testingEnvironment, userManager), ISaleValidation {

        public async Task<int> IsValidAsync(Sale z, SaleWriteDto sale) {
            return true switch {
                var x when x == !await IsValidCustomerId(sale) => 459,
                var x when x == !await IsValidDocumentTypeId(sale) => 460,
                var x when x == !await IsValidPaymentMethodId(sale) => 461,
                var x when x == IsInvalidDiscount(sale) => 462,
                var x when x == IsAlreadyUpdated(z, sale) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidCustomerId(SaleWriteDto sale) {
            return sale.SaleId.ToString() != ""
                ? await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.CustomerId && x.IsActive) != null
                : await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.CustomerId) != null;
        }

        private async Task<bool> IsValidDocumentTypeId(SaleWriteDto sale) {
            return sale.SaleId.ToString() != ""
                ? await context.DocumentTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.DocumentTypeId && x.IsActive) != null
                : await context.DocumentTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.DocumentTypeId) != null;
        }

        private async Task<bool> IsValidPaymentMethodId(SaleWriteDto sale) {
            return sale.SaleId.ToString() != ""
                ? await context.PaymentMethods.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.PaymentMethodId && x.IsActive) != null
                : await context.PaymentMethods.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.PaymentMethodId) != null;
        }

        private static bool IsInvalidDiscount(SaleWriteDto sale) {
            return sale.Items.Select(x => x.DiscountPercent != 0 && x.DiscountAmount != 0).Any(x => x == true);
        }

        private static bool IsAlreadyUpdated(Sale z, SaleWriteDto sale) {
            return z != null && z.PutAt != sale.PutAt;
        }

    }

}