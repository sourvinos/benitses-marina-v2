using API.Infrastructure.Helpers;

namespace API.Features.Boats {

    public static class BoatMappingDtoToDomain {

        public static Boat DtoToDomain(BoatWriteDto boat) {
            return new Boat {
                Id = boat.Id,
                BoatUsageId = boat.BoatUsageId,
                HullTypeId = boat.HullTypeId,
                Description = boat.Description,
                Insurance = new BoatInsurance {
                    Id = boat.Insurance.Id,
                    BoatId = boat.Insurance.BoatId,
                    Company = boat.Insurance.Company,
                    ContractNo = boat.Insurance.ContractNo,
                    ExpireDate = DateHelpers.StringToDate(boat.Insurance.ExpireDate)
                },
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