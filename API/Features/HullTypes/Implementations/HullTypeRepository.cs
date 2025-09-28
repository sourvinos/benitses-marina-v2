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

        public IEnumerable<HullTypeListVM> Get() {
            var hullTypes = context.HullTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return HullTypeMappings.DomainToListVM(hullTypes);
        }

        public IEnumerable<HullTypeBrowserVM> GetForBrowser() {
            var hullTypes = context.HullTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return HullTypeMappings.DomainToBrowserListVM(hullTypes);
        }

        public async Task<HullType> GetByIdAsync(int id) {
            return await context.HullTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}