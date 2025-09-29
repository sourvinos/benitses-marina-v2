using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.SeasonTypes {

    public class SeasonTypeValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<SeasonType>(appDbContext, httpContext, settings, userManager), ISeasonTypeValidation {

        public int IsValid(SeasonType z, SeasonTypeWriteDto boat) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, boat) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(SeasonType z, SeasonTypeWriteDto boat) {
            return z != null && z.PutAt != boat.PutAt;
        }

    }

}