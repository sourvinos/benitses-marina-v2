using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.Features.BoatUsages {

    public class BoatUsageRepository : Repository<BoatUsage>, IBoatUsageRepository {


        public BoatUsageRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<IEnumerable<BoatUsageListVM>> GetAsync() {
            var BoatUsages = await context.BoatUsages
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatUsageMappings.DomainToListVM(BoatUsages);
        }

        public async Task<IEnumerable<BoatUsageBrowserVM>> GetForBrowserAsync() {
            var BoatUsages = await context.BoatUsages
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatUsageMappings.DomainToBrowserListVM(BoatUsages);
        }

        public async Task<BoatUsageBrowserVM> GetByIdForBrowserAsync(int id) {
            var BoatUsage = await context.BoatUsages
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return BoatUsageMappings.DomainToBrowserVM(BoatUsage);
        }

        public async Task<BoatUsage> GetByIdAsync(int id) {
            var x = await context.BoatUsages
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return x;
        }

    }

}