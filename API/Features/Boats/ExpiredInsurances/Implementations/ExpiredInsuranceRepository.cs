using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Boats.Insurances {

    public class ExpiredInsuranceRepository(AppDbContext appDbContext) : IExpiredInsuranceRepository {

        private readonly AppDbContext appDbContext = appDbContext;

        public async Task<IEnumerable<ExpiredInsuranceVM>> GetExpiredInsurances() {
            var boats = await appDbContext.Boats
                .AsNoTracking()
                .Include(x => x.Insurance)
                .Where(x => x.Insurance.ExpireDate <= DateHelpers.GetLocalDateTime() || x.Insurance.ExpireDate == null)
                .ToListAsync();
            return BoatMappingDomainToInsuranceListVM.DomainToListVM(boats);
        }

    }

}