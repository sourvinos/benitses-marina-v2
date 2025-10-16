using API.Infrastructure.Classes;

namespace API.Features.DryDocks {

    public static class DryDockMappingRead {

        public static DryDockReadDto Get(DryDock domainObject) {
            return new DryDockReadDto {
                Id = domainObject.Id.ToString(),
                Boat = new DryDockReadBoatDto {
                    Id = domainObject.Boat.Id,
                    Description = domainObject.Boat.Description,
                    HullType = new SimpleEntity {
                        Id = domainObject.Boat.HullType.Id,
                        Description = domainObject.Boat.HullType.Description
                    }
                },
                Status = new SimpleEntity {
                    Id = domainObject.Status.Id,
                    Description = domainObject.Status.Description
                }
            };
        }

    }

}