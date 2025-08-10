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
            return await (boat.Id == 0 ? GetActiveBoatTypeRecordsAsync(boat) : GetAllBoatTypeRecordsAsync(boat));
        }

        private async Task<bool> IsValidBoatUsageId(BoatWriteDto boat) {
            return await (boat.Id == 0 ? GetActiveBoatUsageRecordsAsync(boat) : GetAllBoatUsageRecordsAsync(boat));
        }

        private async Task<bool> GetActiveBoatTypeRecordsAsync(BoatWriteDto boat) {
            return await context.BoatTypes
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId && x.IsActive) != null;
        }

        private async Task<bool> GetActiveBoatUsageRecordsAsync(BoatWriteDto boat) {
            return await context.BoatUsages
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId && x.IsActive) != null;
        }

        private async Task<bool> GetAllBoatTypeRecordsAsync(BoatWriteDto boat) {
            return await context.BoatTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId) != null;
        }
        private async Task<bool> GetAllBoatUsageRecordsAsync(BoatWriteDto boat) {
            return await context.BoatTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == boat.BoatUsageId) != null;
        }

        private static bool IsAlreadyUpdated(Boat z, BoatWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}