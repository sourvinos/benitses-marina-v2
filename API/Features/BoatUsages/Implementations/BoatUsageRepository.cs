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

    public class BoatUsageRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<BoatUsage>(appDbContext, httpContext, settings, userManager), IBoatUsageRepository {

        public IEnumerable<BoatUsageListVM> Get() {
            var boatUsages = context.BoatUsages
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return BoatUsageMappings.DomainToListVM(boatUsages);
        }

        public IEnumerable<BoatUsageBrowserListVM> GetForBrowser() {
            var boatUsages = context.BoatUsages
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return BoatUsageMappings.DomainToBrowserListVM(boatUsages);
        }

        public async Task<BoatUsage> GetByIdAsync(int id) {
            return await context.BoatUsages
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}