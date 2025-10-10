using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace API.Features.PeriodTypes {

    public class PeriodTypeValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<PeriodType>(appDbContext, httpContext, settings, userManager), IPeriodTypeValidation {

        public async Task<int> IsValidAsync(PeriodType z, PeriodTypeWriteDto periodType) {
            return true switch {
                var x when x == !await IsValidActive(periodType) => 402,
                var x when x == IsAlreadyUpdated(z, periodType) => 415,
                _ => 200,
            };
        }

        private static async Task<bool> IsValidActive(PeriodTypeWriteDto periodType) {
            return periodType.IsActive;
        }

        private static bool IsAlreadyUpdated(PeriodType z, PeriodTypeWriteDto periodType) {
            return z != null && z.PutAt != periodType.PutAt;
        }

    }

}