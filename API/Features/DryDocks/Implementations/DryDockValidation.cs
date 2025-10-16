using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Features.DryDocks {

    public class DryDockValidation(AppDbContext context, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<DryDock>(context, httpContext, testingEnvironment, userManager), IDryDockValidation {

        public async Task<int> IsValidAsync(DryDock z, DryDockWriteDto writeDto) {
            return true switch {
                var x when x == !await IsValidBoatId(writeDto) => 452,
                var x when x == !await IsValidStatusId(writeDto) => 463,
                var x when x == IsAlreadyUpdated(z, writeDto) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBoatId(DryDockWriteDto writeDto) {
            return writeDto.BoatId.ToString() != ""
                ? await context.Boats.AsNoTracking().FirstOrDefaultAsync(x => x.Id == writeDto.BoatId && x.IsActive) != null
                : await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == writeDto.BoatId) != null;
        }

        private async Task<bool> IsValidStatusId(DryDockWriteDto writeDto) {
            return writeDto.StatusId.ToString() != ""
                ? await context.DryDockStatuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == writeDto.StatusId && x.IsActive) != null
                : await context.DryDockStatuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == writeDto.StatusId) != null;
        }

        private static bool IsAlreadyUpdated(DryDock z, DryDockWriteDto writeDto) {
            return z != null && z.PutAt != writeDto.PutAt;
        }

    }

}