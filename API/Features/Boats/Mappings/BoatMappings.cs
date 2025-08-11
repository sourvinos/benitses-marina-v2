using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Boats {

    public static class BoatMappings {

        public static List<BoatListVM> DomainToListVM(List<Boat> boats) {
            return boats.Select(x => new BoatListVM {
                Id = x.Id,
                Description = x.Description,
                Type = new SimpleEntity {
                    Id = x.Type.Id,
                    Description = x.Type.Description
                },
                Usage = new SimpleEntity {
                    Id = x.Usage.Id,
                    Description = x.Usage.Description
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
                Type = new SimpleEntity {
                    Id = boat.Type.Id,
                    Description = boat.Type.Description,
                },
                Usage = new SimpleEntity {
                    Id = boat.Usage.Id,
                    Description = boat.Usage.Description,
                },
                Insurance = new BoatInsuranceReadDto {
                    Id = boat.Insurance.Id,
                    BoatId = boat.Insurance.BoatId,
                    Company = boat.Insurance.Company,
                    ContractNo = boat.Insurance.ContractNo,
                    ExpireDate = boat.Insurance.ExpireDate
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
                Insurance = new BoatInsurance {
                    Id = boat.Insurance.Id,
                    BoatId = boat.Insurance.BoatId,
                    Company = boat.Insurance.Company,
                    ContractNo = boat.Insurance.ContractNo,
                    ExpireDate = DateHelpers.StringToDate(boat.Insurance.ExpireDate)
                },
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