using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDomainToDto {

        public static BoatReadDto DomainToDto(Boat boat) {
            return new BoatReadDto {
                Id = boat.Id,
                Type = new SimpleEntity {
                    Id = boat.HullType.Id,
                    Description = boat.HullType.Description,
                },
                Usage = new SimpleEntity {
                    Id = boat.Usage.Id,
                    Description = boat.Usage.Description,
                },
                Insurance = new BoatInsuranceReadDto {
                    Id = boat.Insurance.Id,
                    BoatId = boat.Insurance.BoatId,
                    Company = boat.Insurance.Company,
                    ContractNo = boat.Insurance.ContractNo,
                    ExpireDate = boat.Insurance.ExpireDate != null ? DateHelpers.DateToISOString((System.DateTime)boat.Insurance.ExpireDate) : ""
                },
                Description = boat.Description,
                Flag = boat.Flag,
                Loa = boat.Loa,
                Beam = boat.Beam,
                Draft = boat.Draft,
                RegistryPort = boat.RegistryPort,
                RegistryNo = boat.RegistryNo,
                IsAthenian = boat.IsAthenian,
                IsFishingBoat = boat.IsFishingBoat,
                IsActive = boat.IsActive,
                PostAt = boat.PostAt,
                PostUser = boat.PostUser,
                PutAt = boat.PutAt,
                PutUser = boat.PutUser
            };
        }

    }

}