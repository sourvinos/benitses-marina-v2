using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace API.Features.TaxOffices {

    public class TaxOfficeValidation(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<TaxOffice>(appDbContext, httpContext, settings, userManager), ITaxOfficeValidation {

        public int IsValid(TaxOffice z, TaxOfficeWriteDto Boat) {
            return true switch {
                var x when x == IsAlreadyUpdated(z, Boat) => 415,
                _ => 200,
            };
        }

        private static bool IsAlreadyUpdated(TaxOffice z, TaxOfficeWriteDto Boat) {
            return z != null && z.PutAt != Boat.PutAt;
        }

    }

}