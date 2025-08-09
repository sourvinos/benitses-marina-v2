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

namespace API.Features.Boats {

    public class BoatRepository : Repository<Boat>, IBoatRepository {

        public BoatRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<IEnumerable<BoatListVM>> GetAsync() {
            var boats = await context.Boats
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatMappings.DomainToListVM(boats);
        }

        public async Task<IEnumerable<BoatBrowserVM>> GetForBrowserAsync() {
            var boats = await context.Boats
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatMappings.DomainToBrowserListVM(boats);
        }

        public async Task<BoatBrowserVM> GetByIdForBrowserAsync(int id) {
            var boat = await context.Boats
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return BoatMappings.DomainToBrowserVM(boat);
        }

        public async Task<Boat> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Boats
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Boats
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}