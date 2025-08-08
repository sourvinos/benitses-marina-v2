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

namespace API.Features.BoatTypes {

    public class BoatTypeRepository : Repository<BoatType>, IBoatTypeRepository {


        public BoatTypeRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<IEnumerable<BoatTypeListVM>> GetAsync() {
            var boatTypes = await context.BoatTypes
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatTypeMappings.DomainToListVM(boatTypes);
        }

        public async Task<IEnumerable<BoatTypeBrowserVM>> GetForBrowserAsync() {
            var boatTypes = await context.BoatTypes
                .AsNoTracking()
                .OrderBy(x => x.Description)
                .ToListAsync();
            return BoatTypeMappings.DomainToBrowserListVM(boatTypes);
        }

        public async Task<BoatTypeBrowserVM> GetByIdForBrowserAsync(int id) {
            var boatType = await context.BoatTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return BoatTypeMappings.DomainToBrowserVM(boatType);
        }

        public async Task<BoatType> GetByIdAsync(int id) {
            var x = await context.BoatTypes
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            return x;
        }

    }

}