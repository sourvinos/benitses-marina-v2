using System.Collections.Generic;
using System.Linq;

namespace API.Features.PeriodTypes {

    public static class PeriodTypeMappings {

        public static IEnumerable<PeriodTypeListVM> DomainToListVM(IQueryable<PeriodType> periodType) {
            return [.. periodType.Select(x => new PeriodTypeListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<PeriodTypeBrowserListVM> DomainToBrowserListVM(IQueryable<PeriodType> periodType) {
            return [.. periodType.Select(x => new PeriodTypeBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static PeriodTypeBrowserListVM DomainToBrowserVM(PeriodType periodType) {
            return new PeriodTypeBrowserListVM {
                Id = periodType.Id,
                Description = periodType.Description,
                IsActive = periodType.IsActive,
            };
        }

        public static PeriodTypeReadDto DomainToDto(PeriodType periodType) {
            return new PeriodTypeReadDto {
                Id = periodType.Id,
                Description = periodType.Description,
                IsActive = periodType.IsActive,
                PostAt = periodType.PostAt,
                PostUser = periodType.PostUser,
                PutAt = periodType.PutAt,
                PutUser = periodType.PutUser
            };
        }

        public static PeriodType DtoToDomail(PeriodTypeWriteDto periodType) {
            return new PeriodType {
                Id = periodType.Id,
                Description = periodType.Description.Trim(),
                IsActive = periodType.IsActive,
                PostAt = periodType.PostAt,
                PostUser = periodType.PostUser,
                PutAt = periodType.PutAt,
                PutUser = periodType.PutUser
            };
        }

    }

}