using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.Features.PaymentMethods {

    public class PaymentMethodRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<PaymentMethod>(appDbContext, httpContext, settings, userManager), IPaymentMethodRepository {

        public IEnumerable<PaymentMethodListVM> Get() {
            var paymentMethods = context.PaymentMethods
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return PaymentMethodMappings.DomainToListVM(paymentMethods);
        }

        public IEnumerable<PaymentMethodBrowserListVM> GetForBrowser() {
            var paymentMethods = context.PaymentMethods
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return PaymentMethodMappings.DomainToBrowserListVM(paymentMethods);
        }

        public async Task<PaymentMethod> GetByIdAsync(int id) {
            return await context.PaymentMethods
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}