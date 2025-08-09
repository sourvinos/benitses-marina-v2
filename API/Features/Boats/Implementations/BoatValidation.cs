using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Features.Boats {

    public class BoatValidation : Repository<BoatWriteDto>, IBoatValidation {


        public BoatValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<int> IsValidAsync(Boat z, BoatWriteDto boat) {
            return true switch {
                var x when x == !await IsValidBoatTypeId(z, boat) => 450,
                var x when x == IsAlreadyUpdated(z, boat) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBoatTypeId(Boat z, BoatWriteDto boat) {
            if (boat.Id != 0) {
                return await context.BoatTypes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId && x.IsActive) != null;
            }
            return await context.BoatTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == boat.BoatTypeId) != null;
        }

        private static bool IsAlreadyUpdated(Boat z, BoatWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}