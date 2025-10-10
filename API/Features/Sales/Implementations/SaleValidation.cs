using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Features.Sales {

    public class SaleValidation(AppDbContext context, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Sale>(context, httpContext, testingEnvironment, userManager), ISaleValidation {

        public async Task<int> IsValidAsync(Sale z, SaleWriteDto sale) {
            return true switch {
                var x when x == !await IsValidCustomerId(sale) => 454,
                var x when x == IsAlreadyUpdated(z, sale) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidCustomerId(SaleWriteDto sale) {
            return sale.SaleId.ToString() != ""
                ? await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.CustomerId && x.IsActive) != null
                : await context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == sale.CustomerId) != null;
        }

        private static bool IsAlreadyUpdated(Sale z, SaleWriteDto sale) {
            return z != null && z.PutAt != sale.PutAt;
        }

    }

}