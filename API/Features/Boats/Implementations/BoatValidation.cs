using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Boats {

    public class BoatValidation : Repository<BoatWriteDto>, IBoatValidation {


        public BoatValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<int> IsValidAsync(Boat z, BoatWriteDto boat) {
            return true switch {
                var x when x == !await IsValidBoatTypeId(boat) => 450,
                var x when x == !await IsValidBoatUsageId(boat) => 451,
                var x when x == IsAlreadyUpdated(z, boat) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBoatTypeId(BoatWriteDto boat) {
            return boat.Id == 0
                ? await context.BoatTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId && x.IsActive) != null
                : await context.BoatTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId) != null;
        }

        private async Task<bool> IsValidBoatUsageId(BoatWriteDto boat) {
            return boat.Id == 0
                ? await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId && x.IsActive) != null
                : await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId) != null;
        }

        private static bool IsAlreadyUpdated(Boat z, BoatWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}