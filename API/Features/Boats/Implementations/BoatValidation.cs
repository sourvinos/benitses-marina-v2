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
                var x when x == !await IsValidBoatUsageId(boat) => 451,
                var x when x == !await IsValidHullTypeId(boat) => 450,
                var x when x == IsAlreadyUpdated(z, boat) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBoatUsageId(BoatWriteDto boat) {
            return boat.Id == 0
                ? await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId && x.IsActive) != null
                : await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId) != null;
        }

        private async Task<bool> IsValidHullTypeId(BoatWriteDto boat) {
            return boat.Id == 0
                ? await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.HullTypeId && x.IsActive) != null
                : await context.HullTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == boat.HullTypeId) != null;
        }

        private static bool IsAlreadyUpdated(Boat z, BoatWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}