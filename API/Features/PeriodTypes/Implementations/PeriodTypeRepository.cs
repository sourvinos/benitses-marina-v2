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

namespace API.Features.PeriodTypes {

    public class PeriodTypeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<PeriodType>(appDbContext, httpContext, settings, userManager), IPeriodTypeRepository {

        public IEnumerable<PeriodTypeListVM> Get() {
            var periodTypes = context.PeriodTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return PeriodTypeMappings.DomainToListVM(periodTypes);
        }

        public IEnumerable<PeriodTypeBrowserListVM> GetForBrowser() {
            var periodTypes = context.PeriodTypes
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return PeriodTypeMappings.DomainToBrowserListVM(periodTypes);
        }

        public async Task<PeriodType> GetByIdAsync(int id) {
            return await context.PeriodTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}