using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;

namespace API.Features.Boats {

    public static class BoatMappings {

        public static List<BoatListVM> DomainToListVM(List<Boat> boats) {
            return boats.Select(x => new BoatListVM {
                Id = x.Id,
                Description = x.Description,
                Type = new SimpleEntity {
                    Id = x.BoatType.Id,
                    Description = x.BoatType.Description
                },
                Usage = new SimpleEntity {
                    Id = x.BoatUsage.Id,
                    Description = x.BoatUsage.Description
                },
                Loa = x.Loa,
                Beam = x.Beam,
                Draft = x.Draft,
                RegistryPort = x.RegistryPort,
                RegistryNo = x.RegistryNo,
                IsAthenian = x.IsAthenian,
                IsFishingBoat = x.IsFishingBoat,
                IsActive = x.IsActive,
            }).ToList();
        }

        public static List<BoatBrowserVM> DomainToBrowserListVM(List<Boat> boats) {
            return boats.Select(x => new BoatBrowserVM {
                Id = x.Id,
                Description = x.Description,
                Loa = x.Loa,
                Beam = x.Beam,
                Draft = x.Draft,
                RegistryPort = x.RegistryPort,
                RegistryNo = x.RegistryNo,
                IsActive = x.IsActive
            }).ToList();
        }

        public static BoatBrowserVM DomainToBrowserVM(Boat boat) {
            return new BoatBrowserVM {
                Id = boat.Id,
                Description = boat.Description,
                Loa = boat.Loa,
                Beam = boat.Beam,
                Draft = boat.Draft,
                IsActive = boat.IsActive
            };
        }

        public static BoatReadDto DomainToDto(Boat boat) {
            return new BoatReadDto {
                Id = boat.Id,
                BoatType = new SimpleEntity {
                    Id = boat.BoatType.Id,
                    Description = boat.BoatType.Description,
                },
                BoatUsage = new SimpleEntity {
                    Id = boat.BoatUsage.Id,
                    Description = boat.BoatUsage.Description,
                },
                Description = boat.Description,
                Flag = boat.Flag,
                Loa = boat.Loa,
                Beam = boat.Beam,
                Draft = boat.Draft,
                RegistryPort = boat.RegistryPort,
                RegistryNo = boat.RegistryNo,
                IsAthenian = boat.IsAthenian,
                IsFishingBoat = boat.IsFishingBoat,
                IsActive = boat.IsActive,
                PostAt = boat.PostAt,
                PostUser = boat.PostUser,
                PutAt = boat.PutAt,
                PutUser = boat.PutUser
            };
        }

        public static Boat DtoToDomain(BoatWriteDto boat) {
            return new Boat {
                Id = boat.Id,
                BoatTypeId = boat.BoatTypeId,
                BoatUsageId = boat.BoatUsageId,
                Description = boat.Description,
                Flag = boat.Flag,
                Loa = boat.Loa,
                Beam = boat.Beam,
                Draft = boat.Draft,
                RegistryPort = boat.RegistryPort,
                RegistryNo = boat.RegistryNo,
                IsAthenian = boat.IsAthenian,
                IsFishingBoat = boat.IsFishingBoat,
                IsActive = boat.IsActive,
                PostAt = boat.PostAt,
                PostUser = boat.PostUser,
                PutAt = boat.PutAt,
                PutUser = boat.PutUser
            };
        }

    }

}