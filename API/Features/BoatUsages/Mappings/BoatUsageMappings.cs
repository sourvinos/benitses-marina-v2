using System.Collections.Generic;
using System.Linq;

namespace API.Features.BoatUsages {

    public static class BoatUsageMappings {

        public static List<BoatUsageListVM> DomainToListVM(List<BoatUsage> BoatUsages) {
            return BoatUsages.Select(x => new BoatUsageListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static List<BoatUsageBrowserVM> DomainToBrowserListVM(List<BoatUsage> BoatUsages) {
            return BoatUsages.Select(x => new BoatUsageBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static BoatUsageBrowserVM DomainToBrowserVM(BoatUsage BoatUsage) {
            return new BoatUsageBrowserVM {
                Id = BoatUsage.Id,
                Description = BoatUsage.Description,
                IsActive = BoatUsage.IsActive,
            };
        }

        public static BoatUsageReadDto DomainToDto(BoatUsage BoatUsage) {
            return new BoatUsageReadDto {
                Id = BoatUsage.Id,
                Description = BoatUsage.Description,
                IsActive = BoatUsage.IsActive,
                PostAt = BoatUsage.PostAt,
                PostUser = BoatUsage.PostUser,
                PutAt = BoatUsage.PutAt,
                PutUser = BoatUsage.PutUser
            };
        }

        public static BoatUsage DtoToDomail(BoatUsageWriteDto BoatUsage) {
            return new BoatUsage {
                Id = BoatUsage.Id,
                Description = BoatUsage.Description.Trim(),
                IsActive = BoatUsage.IsActive,
                PostAt = BoatUsage.PostAt,
                PostUser = BoatUsage.PostUser,
                PutAt = BoatUsage.PutAt,
                PutUser = BoatUsage.PutUser
            };
        }

    }

}