using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.Nationalities {

    public class NationalityValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Nationality>(appDbContext, httpContext, settings, userManager), INationalityValidation {

        public int IsValid(Nationality z, NationalityWriteDto nationality) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, nationality) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(Nationality z, NationalityWriteDto nationality) {
            return z != null && z.PutAt != nationality.PutAt;
        }

    }

}