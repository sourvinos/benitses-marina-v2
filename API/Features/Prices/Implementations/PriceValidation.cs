using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Prices {

    public class PriceValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Price>(appDbContext, httpContext, settings, userManager), IPriceValidation {

        public async Task<int> IsValidAsync(Price z, PriceWriteDto price) {
            return true switch {
                var x when x == !await IsValidHullTypeId(price) => 451,
                var x when x == !await IsValidPeriodTypeId(price) => 455,
                var x when x == !await IsValidSeasonTypeId(price) => 456,
                var x when x == IsAlreadyUpdated(z, price) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidHullTypeId(PriceWriteDto price) {
            return price.Id == 0
                ? await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == price.HullTypeId && x.IsActive) != null
                : await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == price.HullTypeId) != null;
        }

        private async Task<bool> IsValidPeriodTypeId(PriceWriteDto price) {
            return price.Id == 0
                ? await context.PeriodTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == price.PeriodTypeId && x.IsActive) != null
                : await context.PeriodTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == price.PeriodTypeId) != null;
        }

        private async Task<bool> IsValidSeasonTypeId(PriceWriteDto boat) {
            return boat.Id == 0
                ? await context.SeasonTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.SeasonTypeId && x.IsActive) != null
                : await context.SeasonTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.SeasonTypeId) != null;
        }

        private static bool IsAlreadyUpdated(Price z, PriceWriteDto price) {
            return z != null && z.PutAt != price.PutAt;
        }

    }

}