using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Items {

    public class ItemValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Item>(appDbContext, httpContext, settings, userManager), IItemValidation {

        public async Task<int> IsValidAsync(Item z, ItemWriteDto item) {
            return true switch {
                var x when x == !await IsValidHullTypeId(item) => 451,
                var x when x == !await IsValidPeriodTypeId(item) => 455,
                var x when x == !await IsValidSeasonTypeId(item) => 456,
                var x when x == IsAlreadyUpdated(z, item) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidHullTypeId(ItemWriteDto item) {
            return item.Id == 0
                ? await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.HullTypeId && x.IsActive) != null
                : await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.HullTypeId) != null;
        }

        private async Task<bool> IsValidPeriodTypeId(ItemWriteDto item) {
            return item.Id == 0
                ? await context.PeriodTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.PeriodTypeId && x.IsActive) != null
                : await context.PeriodTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.PeriodTypeId) != null;
        }

        private async Task<bool> IsValidSeasonTypeId(ItemWriteDto periodType) {
            return periodType.Id == 0
                ? await context.SeasonTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == periodType.SeasonTypeId && x.IsActive) != null
                : await context.SeasonTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == periodType.SeasonTypeId) != null;
        }

        private static bool IsAlreadyUpdated(Item z, ItemWriteDto item) {
            return z != null && z.PutAt != item.PutAt;
        }

    }

}