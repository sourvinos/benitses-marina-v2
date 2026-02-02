using System.Collections.Generic;
using System.Linq;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToBrowserListVM {

        public static IEnumerable<BoatBrowserListVM> DomainToBrowserListVM(IQueryable<Boat> boats) {
            return [.. boats.Select(x => new BoatBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

    }

}