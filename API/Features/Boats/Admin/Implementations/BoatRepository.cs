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

namespace API.Features.Boats.Admin {

    public class BoatRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Boat>(appDbContext, httpContext, testingEnvironment, userManager), IBoatRepository {

        public IEnumerable<BoatListVM> Get() {
            var boats = context.Boats
                .AsNoTracking()
                .Include(x => x.HullType)
                .Include(x => x.Usage)
                .OrderBy(x => x.Description);
            return BoatMappingDomainToListVM.DomainToListVM(boats);
        }

        public IEnumerable<BoatBrowserVM> GetForBrowser() {
            var boats = context.Boats
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return BoatMappingDomainToBrowserListVM.DomainToBrowserListVM(boats);
        }

        public async Task<Boat> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Boats
                    .AsNoTracking()
                    .Include(x => x.HullType)
                    .Include(x => x.Usage)
                    .Include(x => x.FishingLicence)
                    .Include(x => x.Insurance)
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Boats
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}