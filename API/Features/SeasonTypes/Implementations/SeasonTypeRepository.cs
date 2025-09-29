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

namespace API.Features.SeasonTypes {

    public class SeasonTypeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<SeasonType>(appDbContext, httpContext, settings, userManager), ISeasonTypeRepository {

        public IEnumerable<SeasonTypeListVM> Get() {
            var seasonTypes = context.SeasonTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return SeasonTypeMappings.DomainToListVM(seasonTypes);
        }

        public IEnumerable<SeasonTypeBrowserListVM> GetForBrowser() {
            var seasonTypes = context.SeasonTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return SeasonTypeMappings.DomainToBrowserListVM(seasonTypes);
        }

        public async Task<SeasonTypeBrowserListVM> GetByIdForBrowserAsync(int id) {
            var seasonType = await context.SeasonTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return SeasonTypeMappings.DomainToBrowserVM(seasonType);
        }

        public async Task<SeasonType> GetByIdAsync(int id) {
            return await context.SeasonTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}