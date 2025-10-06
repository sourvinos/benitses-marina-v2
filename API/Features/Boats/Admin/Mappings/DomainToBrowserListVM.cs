using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Helpers;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToBrowserListVM {

        public static IEnumerable<BoatBrowserListVM> DomainToBrowserListVM(IQueryable<Boat> boats) {
            return [.. boats.Select(x => new BoatBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                Loa = x.Loa,
                Beam = x.Beam,
                Draft = x.Draft,
                RegistryPort = x.RegistryPort,
                RegistryNo = x.RegistryNo,
                IsAthenian = x.IsAthenian,
                IsFishingBoat = x.IsFishingBoat,
                IsInsuranceValid = x.Insurance.ExpireDate >= DateHelpers.GetLocalDateTime() || x.Insurance.ExpireDate != null,
                IsActive = x.IsActive,
            })];
        }

    }

}