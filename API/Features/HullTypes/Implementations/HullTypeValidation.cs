using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.HullTypes {

    public class HullTypeValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<HullType>(appDbContext, httpContext, settings, userManager), IHullTypeValidation {

        public int IsValid(HullType z, HullTypeWriteDto Boat) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, Boat) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(HullType z, HullTypeWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}