using System.Collections.Generic;
using System.Linq;

namespace API.Features.Berths {

    public static class BerthMappings {

        public static IEnumerable<BerthListVM> DomainToListVM(IQueryable<Berth> berth) {
            return [.. berth.Select(x => new BerthListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static IEnumerable<BerthBrowserVM> DomainToBrowserListVM(IQueryable<Berth> berth) {
            return [.. berth.Select(x => new BerthBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static BerthReadDto DomainToDto(Berth berth) {
            return new BerthReadDto {
                Id = berth.Id,
                Description = berth.Description,
                IsActive = berth.IsActive,
                PostAt = berth.PostAt,
                PostUser = berth.PostUser,
                PutAt = berth.PutAt,
                PutUser = berth.PutUser
            };
        }

        public static Berth DtoToDomail(BerthWriteDto berth) {
            return new Berth {
                Id = berth.Id,
                Description = berth.Description.Trim(),
                IsActive = berth.IsActive,
                PostAt = berth.PostAt,
                PostUser = berth.PostUser,
                PutAt = berth.PutAt,
                PutUser = berth.PutUser
            };
        }

    }

}