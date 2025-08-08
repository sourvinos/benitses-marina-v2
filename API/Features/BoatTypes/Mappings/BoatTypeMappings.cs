using System.Collections.Generic;
using System.Linq;

namespace API.Features.BoatTypes {

    public static class BoatTypeMappings {

        public static List<BoatTypeListVM> DomainToListVM(List<BoatType> boatTypes) {
            return boatTypes.Select(x => new BoatTypeListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static List<BoatTypeBrowserVM> DomainToBrowserListVM(List<BoatType> boatTypes) {
            return boatTypes.Select(x => new BoatTypeBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static BoatTypeBrowserVM DomainToBrowserVM(BoatType boatType) {
            return new BoatTypeBrowserVM {
                Id = boatType.Id,
                Description = boatType.Description,
                IsActive = boatType.IsActive,
            };
        }

        public static BoatTypeReadDto DomainToDto(BoatType boatType) {
            return new BoatTypeReadDto {
                Id = boatType.Id,
                Description = boatType.Description,
                IsActive = boatType.IsActive,
                PostAt = boatType.PostAt,
                PostUser = boatType.PostUser,
                PutAt = boatType.PutAt,
                PutUser = boatType.PutUser
            };
        }

        public static BoatType DtoToDomail(BoatTypeWriteDto boatType) {
            return new BoatType {
                Id = boatType.Id,
                Description = boatType.Description.Trim(),
                IsActive = boatType.IsActive,
                PostAt = boatType.PostAt,
                PostUser = boatType.PostUser,
                PutAt = boatType.PutAt,
                PutUser = boatType.PutUser
            };
        }

    }

}