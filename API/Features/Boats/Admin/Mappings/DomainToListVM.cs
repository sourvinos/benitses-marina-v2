using System.Collections.Generic;
using System.Linq;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToListVM {

        public static IEnumerable<BoatListVM> DomainToListVM(IQueryable<Boat> boats) {
            return [.. boats.Select(x => new BoatListVM {
                Id = x.Id,
                Description = x.Description,
                Nationality = new BoatListNationalityVM {
                    Id = x.Nationality.Id,
                    Code = x.Nationality.Code,
                    Description = x.Nationality.Description,
                    IsActive = x.Nationality.IsActive
                },
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