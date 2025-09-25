using API.Infrastructure.Helpers;

namespace API.Features.Boats.Admin {

    public static class BoatMappingDtoPutToDomain {

        public static Boat DtoPutToDomain(Boat x, BoatWriteDto boat) {
            return new Boat {
                Id = boat.Id,
                BoatUsageId = boat.BoatUsageId,
                HullTypeId = boat.HullTypeId,
                Description = boat.Description,
                Insurance = new BoatInsurance {
                    Id = x.Insurance.Id,
                    BoatId = x.Insurance.BoatId,
                    Company = boat.Insurance != null ? boat.Insurance.Company : "",
                    ContractNo = boat.Insurance != null ? boat.Insurance.ContractNo : "",
                    ExpireDate = boat.Insurance != null ? (boat.Insurance.ExpireDate != null ? DateHelpers.StringToDate(boat.Insurance.ExpireDate) : null) : null
                },
                FishingLicence = new BoatFishingLicence {
                    Id = x.FishingLicence.Id,
                    BoatId = x.FishingLicence.BoatId,
                    IssuingAuthority = boat.FishingLicence != null ? boat.FishingLicence.IssuingAuthority : "",
                    LicenceNo = boat.FishingLicence != null ? boat.FishingLicence.LicenceNo : "",
                    ExpireDate = boat.FishingLicence != null ? (boat.FishingLicence.ExpireDate != null ? DateHelpers.StringToDate(boat.FishingLicence.ExpireDate) : null) : null
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