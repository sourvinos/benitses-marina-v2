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

        public async Task<IEnumerable<BerthListVM>> GetAsync() {
            var berths = await context.Berths
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BerthMappings.DomainToListVM(berths);
        }

        public async Task<IEnumerable<BerthBrowserVM>> GetForBrowserAsync() {
            var berths = await context.Berths
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BerthMappings.DomainToBrowserListVM(berths);
        }

        public async Task<BerthBrowserVM> GetByIdForBrowserAsync(int id) {
            var berth = await context.Berths
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return BerthMappings.DomainToBrowserVM(berth);
        }

        public async Task<Berth> GetByIdAsync(int id) {
            return await context.Berths
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}