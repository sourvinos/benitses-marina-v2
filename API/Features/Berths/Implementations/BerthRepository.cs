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

namespace API.Features.Berths {

    public class BerthRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Berth>(appDbContext, httpContext, settings, userManager), IBerthRepository {

        public IEnumerable<BerthListVM> Get() {
            var berths = context.Berths
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return BerthMappings.DomainToListVM(berths);
        }

        public IEnumerable<BerthBrowserListVM> GetForBrowser() {
            var berths = context.Berths
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return BerthMappings.DomainToBrowserListVM(berths);
        }

        public async Task<Berth> GetByIdAsync(int id) {
            return await context.Berths
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}