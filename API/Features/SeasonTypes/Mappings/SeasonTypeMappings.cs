using System.Collections.Generic;
using System.Linq;

namespace API.Features.SeasonTypes {

    public static class SeasonTypeMappings {

        public static IEnumerable<SeasonTypeListVM> DomainToListVM(IQueryable<SeasonType> seasonType) {
            return [.. seasonType.Select(x => new SeasonTypeListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<SeasonTypeBrowserListVM> DomainToBrowserListVM(IQueryable<SeasonType> seasonType) {
            return [.. seasonType.Select(x => new SeasonTypeBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static SeasonTypeBrowserListVM DomainToBrowserVM(SeasonType seasonType) {
            return new SeasonTypeBrowserListVM {
                Id = seasonType.Id,
                Description = seasonType.Description,
                IsActive = seasonType.IsActive,
            };
        }

        public static SeasonTypeReadDto DomainToDto(SeasonType seasonType) {
            return new SeasonTypeReadDto {
                Id = seasonType.Id,
                Description = seasonType.Description,
                IsActive = seasonType.IsActive,
                PostAt = seasonType.PostAt,
                PostUser = seasonType.PostUser,
                PutAt = seasonType.PutAt,
                PutUser = seasonType.PutUser
            };
        }

        public static SeasonType DtoToDomail(SeasonTypeWriteDto seasonType) {
            return new SeasonType {
                Id = seasonType.Id,
                Description = seasonType.Description.Trim(),
                IsActive = seasonType.IsActive,
                PostAt = seasonType.PostAt,
                PostUser = seasonType.PostUser,
                PutAt = seasonType.PutAt,
                PutUser = seasonType.PutUser
            };
        }

    }

}