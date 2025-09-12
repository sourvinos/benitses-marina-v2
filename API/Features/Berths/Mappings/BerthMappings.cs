using System.Collections.Generic;
using System.Linq;

namespace API.Features.Berths {

    public static class BerthMappings {

        public static List<BerthListVM> DomainToListVM(List<Berth> berth) {
            return [.. berth.Select(x => new BerthListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static List<BerthBrowserVM> DomainToBrowserListVM(List<Berth> berth) {
            return [.. berth.Select(x => new BerthBrowserVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

        public static BerthBrowserVM DomainToBrowserVM(Berth berth) {
            return new BerthBrowserVM {
                Id = berth.Id,
                Description = berth.Description,
                IsActive = berth.IsActive,
            };
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