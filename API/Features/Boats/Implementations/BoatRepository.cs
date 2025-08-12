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

namespace API.Features.Boats {

    public class BoatRepository : Repository<Boat>, IBoatRepository {

        public BoatRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<IEnumerable<BoatListVM>> GetAsync() {
            var boats = await context.Boats
                .AsNoTracking()
                .Include(x => x.Type)
                .Include(x => x.Usage)
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatMappingDomainToListVM.DomainToListVM(boats);
        }

        public async Task<IEnumerable<BoatBrowserVM>> GetForBrowserAsync() {
            var boats = await context.Boats
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatMappingDomainToBrowserListVM.DomainToBrowserListVM(boats);
        }

        public async Task<BoatBrowserVM> GetByIdForBrowserAsync(int id) {
            var boat = await context.Boats
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return BoatMappingDomainToBrowserVM.DomainToBrowserVM(boat);
        }

        public async Task<Boat> GetByIdAsync(int id, bool includeTables) {
            return includeTables
                ? await context.Boats
                    .AsNoTracking()
                    .Include(x => x.Type)
                    .Include(x => x.Usage)
                    .Include(x => x.Insurance)
                    .SingleOrDefaultAsync(x => x.Id == id)
                : await context.Boats
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public BoatWriteDto UpdateInsurancePutDto(Boat x, BoatWriteDto boat) {
            boat.Insurance.Id = x.Insurance.Id;
            boat.Insurance.BoatId = x.Insurance.BoatId;
            return boat;
        }

    }

}