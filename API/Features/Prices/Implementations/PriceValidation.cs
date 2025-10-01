using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.Prices {

    public class PriceValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Price>(appDbContext, httpContext, settings, userManager), IPriceValidation {

        public int IsValid(Price z, PriceWriteDto price) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, price) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(Price z, PriceWriteDto price) {
            return z != null && z.PutAt != price.PutAt;
        }

    }

}