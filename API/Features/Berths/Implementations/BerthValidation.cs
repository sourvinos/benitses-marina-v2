using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.Berths {

    public class BerthValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Berth>(appDbContext, httpContext, settings, userManager), IBerthValidation {

        public int IsValid(Berth z, BerthWriteDto berth) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, berth) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(Berth z, BerthWriteDto berth) {
            return z != null && z.PutAt != berth.PutAt;
        }

    }

}