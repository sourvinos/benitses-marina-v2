using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Customers.Admin {

    public class CustomerValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<CustomerWriteDto>(appDbContext, httpContext, settings, userManager), ICustomerValidation {

        public async Task<int> IsValidAsync(Customer z, CustomerWriteDto customer) {
            return true switch {
                var x when x == !await IsValidNationalityId(customer) => 457,
                var x when x == !await IsValidTaxOfficeId(customer) => 458,
                var x when x == IsAlreadyUpdated(z, customer) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidNationalityId(CustomerWriteDto customer) {
            return customer.Id == 0
                ? await context.Nationalities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customer.NationalityId && x.IsActive) != null
                : await context.Nationalities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customer.NationalityId) != null;
        }

        private async Task<bool> IsValidTaxOfficeId(CustomerWriteDto customer) {
            return customer.Id == 0
                ? await context.TaxOffices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customer.TaxOfficeId && x.IsActive) != null
                : await context.TaxOffices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == customer.TaxOfficeId) != null;
        }

        private static bool IsAlreadyUpdated(Customer z, CustomerWriteDto Customer) {
            return z != null && z.PutAt != Customer.PutAt;
        }

    }

}