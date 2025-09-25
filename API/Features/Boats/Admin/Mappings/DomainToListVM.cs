using System.Collections.Generic;
using System.Linq;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToListVM {

        public static List<BoatListVM> DomainToListVM(List<Boat> boats) {
            return [.. boats.Select(x => new BoatListVM {
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
            })];
        }

    }

}