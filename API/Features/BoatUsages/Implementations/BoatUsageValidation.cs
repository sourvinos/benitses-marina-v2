using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.BoatUsages {

    public class BoatUsageValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<BoatUsage>(appDbContext, httpContext, settings, userManager), IBoatUsageValidation {

        public int IsValid(BoatUsage z, BoatUsageWriteDto boatUsage) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, boatUsage) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(BoatUsage z, BoatUsageWriteDto boatUsage) {
            return z != null && z.PutAt != boatUsage.PutAt;
        }

    }

}