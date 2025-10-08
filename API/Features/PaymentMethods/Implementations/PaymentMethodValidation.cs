using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.PaymentMethods {

    public class PaymentMethodValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<PaymentMethod>(appDbContext, httpContext, settings, userManager), IPaymentMethodValidation {

        public int IsValid(PaymentMethod z, PaymentMethodWriteDto paymentMethod) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, paymentMethod) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(PaymentMethod z, PaymentMethodWriteDto paymentMethod) {
            return z != null && z.PutAt != paymentMethod.PutAt;
        }

    }

}