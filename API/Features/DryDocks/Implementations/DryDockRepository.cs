using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Features.DryDocks {

    public class DryDockRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<DryDock>(appDbContext, httpContext, settings, userManager), IDryDockRepository {

        public IEnumerable<DryDockListVM> Get() {
            var dryDocks = context.DryDocks
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.HullType)
                .Include(x => x.Status)
                .Where(x => !x.IsDeleted);
            return DryDockMappingReadToList.Get(dryDocks);
        }

        public async Task<DryDock> GetByIdAsync(string id, bool includeTables) {
            return includeTables
                ? await context.DryDocks
                    .AsNoTracking()
                    .Include(x => x.Boat).ThenInclude(x => x.HullType)
                    .Include(x => x.Status)
                    .Where(x => x.Id.ToString() == id)
                    .SingleOrDefaultAsync()
               : await context.DryDocks
                  .AsNoTracking()
                  .Where(x => x.Id.ToString() == id)
                  .SingleOrDefaultAsync();
        }

    }

}