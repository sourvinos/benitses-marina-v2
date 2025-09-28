using System.Collections.Generic;
using System.Linq;

namespace API.Features.HullTypes {

    public static class HullTypeMappings {

        public static IEnumerable<HullTypeListVM> DomainToListVM(IQueryable<HullType> hullTypes) {
            return [.. hullTypes.Select(x => new HullTypeListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<HullTypeBrowserVM> DomainToBrowserListVM(IQueryable<HullType> hullTypes) {
            return [.. hullTypes.Select(x => new HullTypeBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static HullTypeBrowserVM DomainToBrowserVM(HullType hullType) {
            return new HullTypeBrowserVM {
                Id = hullType.Id,
                Description = hullType.Description,
                IsActive = hullType.IsActive,
            };
        }

        public static HullTypeReadDto DomainToDto(HullType hullType) {
            return new HullTypeReadDto {
                Id = hullType.Id,
                Description = hullType.Description,
                IsActive = hullType.IsActive,
                PostAt = hullType.PostAt,
                PostUser = hullType.PostUser,
                PutAt = hullType.PutAt,
                PutUser = hullType.PutUser
            };
        }

        public static HullType DtoToDomail(HullTypeWriteDto hullType) {
            return new HullType {
                Id = hullType.Id,
                Description = hullType.Description.Trim(),
                IsActive = hullType.IsActive,
                PostAt = hullType.PostAt,
                PostUser = hullType.PostUser,
                PutAt = hullType.PutAt,
                PutUser = hullType.PutUser
            };
        }

    }

}