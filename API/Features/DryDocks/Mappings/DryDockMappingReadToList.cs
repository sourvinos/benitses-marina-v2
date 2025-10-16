using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;

namespace API.Features.DryDocks {

    public static class DryDockMappingReadToList {

        public static IEnumerable<DryDockListVM> Get(IQueryable<DryDock> domainObjects) {
            return [.. domainObjects.Select(x => new DryDockListVM {
                Id = x.Id.ToString(),
                Boat = new DryDockListBoatVM {
                        Id = x.Boat.Id,
                        Description = x.Boat.Description,
                        HullType = new SimpleEntity {
                            Id = x.Boat.HullType.Id,
                            Description = x.Boat.HullType.Description
                        }
                    },
                Status = new SimpleEntity {
                    Id = x.Status.Id,
                    Description = x.Status.Description
                }
            })];
        }

    }

}