using System.Collections.Generic;
using System.Linq;

namespace API.Features.Boats {

    public static class BoatMappingDomainToBrowserListVM {

        public static List<BoatBrowserVM> DomainToBrowserListVM(List<Boat> boats) {
            return boats.Select(x => new BoatBrowserVM {
                Id = x.Id,
                Description = x.Description,
                Loa = x.Loa,
                Beam = x.Beam,
                Draft = x.Draft,
                RegistryPort = x.RegistryPort,
                RegistryNo = x.RegistryNo,
                IsAthenian = x.IsAthenian,
                IsFishingBoat = x.IsFishingBoat,
                IsActive = x.IsActive,
            }).ToList();
        }
 
   }

}