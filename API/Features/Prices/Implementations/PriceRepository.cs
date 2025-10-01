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

namespace API.Features.Prices {

    public class PriceRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Price>(appDbContext, httpContext, settings, userManager), IPriceRepository {

        public IEnumerable<PriceListVM> Get() {
            var prices = context.Prices
                .AsNoTracking()
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .OrderBy(x => x.Description);
            return PriceMappingDomainToListVM.Get(prices);
        }

        public IEnumerable<PriceListBrowserVM> GetForBrowser() {
            var prices = context.Prices
                .AsNoTracking()
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .OrderBy(x => x.Description);
            return PriceMappingDomainToBrowserListVM.Get(prices);
        }

        public async Task<Price> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Prices
                    .Include(x => x.HullType)
                    .Include(x => x.PeriodType)
                    .Include(x => x.SeasonType)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Prices
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Price> GetByCodeAsync(string code) {
            return await context.Prices
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Code == code);
        }

    }

}