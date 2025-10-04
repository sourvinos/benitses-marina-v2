using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Customers.Admin {

    public class CustomerRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Customer>(appDbContext, httpContext, testingEnvironment, userManager), ICustomerRepository {

        public IEnumerable<CustomerListVM> Get() {
            var customers = context.Customers
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return CustomerMappingDomainToListVM.DomainToListVM(customers);
        }

        public IEnumerable<CustomerBrowserListVM> GetForBrowser() {
            var customers = context.Customers
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return CustomerMappingDomainToBrowserListVM.DomainToBrowserListVM(customers);
        }

        public async Task<Customer> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Customers
                    .AsNoTracking()
                    .Include(x => x.Nationality)
                    .Include(x => x.TaxOffice)
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Customers
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}