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

namespace API.Features.TaxOffices {

    public class TaxOfficeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<TaxOffice>(appDbContext, httpContext, settings, userManager), ITaxOfficeRepository {

        public IEnumerable<TaxOfficeListVM> Get() {
            var taxOffices = context.TaxOffices
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return TaxOfficeMappings.DomainToListVM(taxOffices);
        }

        public IEnumerable<TaxOfficeBrowserListVM> GetForBrowser() {
            var taxOffices = context.TaxOffices
                .AsNoTracking()
                .OrderBy(x => x.Description);
            return TaxOfficeMappings.DomainToBrowserListVM(taxOffices);
        }

        public async Task<TaxOffice> GetByIdAsync(int id) {
            return await context.TaxOffices
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

    }

}