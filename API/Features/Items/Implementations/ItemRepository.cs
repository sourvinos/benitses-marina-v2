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

namespace API.Features.Items {

    public class ItemRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Item>(appDbContext, httpContext, settings, userManager), IItemRepository {

        public IEnumerable<ItemListVM> Get() {
            var items = context.Items
                .AsNoTracking()
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .OrderBy(x => x.Description);
            return ItemMappingDomainToListVM.Get(items);
        }

        public IEnumerable<ItemBrowserListVM> GetForBrowser() {
            var items = context.Items
                .AsNoTracking()
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .OrderBy(x => x.Description);
            return ItemMappingDomainToBrowserListVM.Get(items);
        }

        public async Task<Item> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Items
                    .Include(x => x.HullType)
                    .Include(x => x.PeriodType)
                    .Include(x => x.SeasonType)
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Items
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Item> GetByCodeAsync(string code) {
            return await context.Items
                .Include(x => x.HullType)
                .Include(x => x.PeriodType)
                .Include(x => x.SeasonType)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Code == code);
        }

    }

}