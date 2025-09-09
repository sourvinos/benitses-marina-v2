using API.Infrastructure.Helpers;

namespace API.Features.Boats {

    public static class BoatMappingDtoPostToDomain {

        public static Boat DtoPostToDomain(BoatWriteDto boat) {
            var x = new Boat {
                Id = boat.Id,
                BoatUsageId = boat.BoatUsageId,
                HullTypeId = boat.HullTypeId,
                Description = boat.Description,
                Insurance = new BoatInsurance {
                    BoatId = boat.Id,
                    Company = boat.Insurance.Company,
                    ContractNo = boat.Insurance.ContractNo,
                    ExpireDate = boat.Insurance.ExpireDate != null ? DateHelpers.StringToDate(boat.Insurance.ExpireDate) : null
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
            return x;
        }

    }

}