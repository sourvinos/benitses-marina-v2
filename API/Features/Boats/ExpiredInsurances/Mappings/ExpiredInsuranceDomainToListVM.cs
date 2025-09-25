using System;
using System.Collections.Generic;
using System.Linq;
using API.Features.Boats.Admin;
using API.Infrastructure.Helpers;

namespace API.Features.Boats.Insurances {

    public static class BoatMappingDomainToInsuranceListVM {

        public static IEnumerable<ExpiredInsuranceVM> DomainToListVM(IEnumerable<Boat> boats) {
            return boats.Select(x => new ExpiredInsuranceVM {
                Boat = new ExpiredInsuranceBoatVM {
                    Id = x.Id,
                    Description = x.Description,
                    RegistryNo = x.RegistryNo,
                    IsAthenian = x.IsAthenian,
                    IsFishingBoat = x.IsFishingBoat
                },
                ExpireDate = x.Insurance.ExpireDate != null ? DateHelpers.DateToISOString((DateTime)(x.Insurance.ExpireDate ?? null)) : ""
            });
        }

    }

}