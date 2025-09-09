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

namespace API.Features.HullTypes {

    public class HullTypeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<HullType>(appDbContext, httpContext, settings, userManager), IHullTypeRepository {

        public async Task<IEnumerable<HullTypeListVM>> GetAsync() {
            var hullTypes = await context.HullTypes
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return HullTypeMappings.DomainToListVM(hullTypes);
        }

        public async Task<IEnumerable<HullTypeBrowserVM>> GetForBrowserAsync() {
            var hullTypes = await context.HullTypes
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return HullTypeMappings.DomainToBrowserListVM(hullTypes);
        }

        public async Task<HullTypeBrowserVM> GetByIdForBrowserAsync(int id) {
            var hullType = await context.HullTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return HullTypeMappings.DomainToBrowserVM(hullType);
        }

        public async Task<HullType> GetByIdAsync(int id) {
            return await context.HullTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}