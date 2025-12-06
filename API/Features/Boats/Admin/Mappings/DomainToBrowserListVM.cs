using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToBrowserListVM {

        public static IEnumerable<BoatBrowserListVM> DomainToBrowserListVM(IQueryable<Boat> boats) {
            return [.. boats.Select(x => new BoatBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                HullType = new SimpleEntity {
                    Id = x.HullType.Id,
                    Description = x.HullType.Description
                },
                Usage = new SimpleEntity {
                    Id = x.Usage.Id,
                    Description = x.Usage.Description
                },
                Insurance = new BoatBrowserListInsuranceVM {
                    Company = x.Insurance.Company,
                    ContractNo = x.Insurance.ContractNo,
                    ExpireDate = x.Insurance.ExpireDate.ToString()
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