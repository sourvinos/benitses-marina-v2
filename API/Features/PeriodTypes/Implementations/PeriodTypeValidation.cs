using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.PeriodTypes {

    public class PeriodTypeValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<PeriodType>(appDbContext, httpContext, settings, userManager), IPeriodTypeValidation {

        public int IsValid(PeriodType z, PeriodTypeWriteDto periodType) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, periodType) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(PeriodType z, PeriodTypeWriteDto periodType) {
            return z != null && z.PutAt != periodType.PutAt;
        }

    }

}