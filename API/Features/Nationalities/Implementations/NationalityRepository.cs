using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Nationalities {

    public class NationalityRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Nationality>(appDbContext, httpContext, settings, userManager), INationalityRepository {

        public IEnumerable<NationalityListVM> Get() {
            var nationalities = context.Nationalities
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return NationalityMappings.DomainToListVM(nationalities);
        }

        public IEnumerable<NationalityBrowserListVM> GetForBrowser() {
            var nationalities = context.Nationalities
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return NationalityMappings.DomainToBrowserListVM(nationalities);
        }

        public async Task<Nationality> GetByIdAsync(int id) {
            return await context.Nationalities
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}