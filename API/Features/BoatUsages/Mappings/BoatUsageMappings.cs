using System.Collections.Generic;
using System.Linq;

namespace API.Features.BoatUsages {

    public static class BoatUsageMappings {

        public static IEnumerable<BoatUsageListVM> DomainToListVM(IQueryable<BoatUsage> boatUsages) {
            return [.. boatUsages.Select(x => new BoatUsageListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<BoatUsageBrowserVM> DomainToBrowserListVM(IQueryable<BoatUsage> boatUsages) {
            return [.. boatUsages.Select(x => new BoatUsageBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static BoatUsageBrowserVM DomainToBrowserVM(BoatUsage boatUsage) {
            return new BoatUsageBrowserVM {
                Id = boatUsage.Id,
                Description = boatUsage.Description,
                IsActive = boatUsage.IsActive,
            };
        }

        public static BoatUsageReadDto DomainToDto(BoatUsage boatUsage) {
            return new BoatUsageReadDto {
                Id = boatUsage.Id,
                Description = boatUsage.Description,
                IsActive = boatUsage.IsActive,
                PostAt = boatUsage.PostAt,
                PostUser = boatUsage.PostUser,
                PutAt = boatUsage.PutAt,
                PutUser = boatUsage.PutUser
            };
        }

        public static BoatUsage DtoToDomail(BoatUsageWriteDto boatUsage) {
            return new BoatUsage {
                Id = boatUsage.Id,
                Description = boatUsage.Description.Trim(),
                IsActive = boatUsage.IsActive,
                PostAt = boatUsage.PostAt,
                PostUser = boatUsage.PostUser,
                PutAt = boatUsage.PutAt,
                PutUser = boatUsage.PutUser
            };
        }

    }

}