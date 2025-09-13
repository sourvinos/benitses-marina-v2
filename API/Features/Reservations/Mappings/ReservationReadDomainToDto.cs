using System;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingReadDomainToDto {

        public static ReservationReadDto ReservationReadDomainToDto(Reservation reservation) {
            return new ReservationReadDto {
                ReservationId = reservation.ReservationId.ToString(),
                Boat = new ReservationBoatReadDto {
                    Id = reservation.Boat.Id,
                    Description = reservation.Boat.Description,
                    Usage = new SimpleEntity {
                        Id = reservation.Boat.Usage.Id,
                        Description = reservation.Boat.Usage.Description
                    },
                    HullType = new SimpleEntity {
                        Id = reservation.Boat.HullType.Id,
                        Description = reservation.Boat.HullType.Description
                    },
                    Insurance = new ReservationBoatInsuranceReadDto {
                        Id = reservation.Boat.Insurance.Id,
                        BoatId = reservation.Boat.Insurance.BoatId,
                        Company = reservation.Boat.Insurance.Company,
                        ContractNo = reservation.Boat.Insurance.ContractNo,
                        ExpireDate = reservation.Boat.Insurance.ExpireDate != null ? DateHelpers.DateToISOString((DateTime)reservation.Boat.Insurance.ExpireDate) : "",
                        IsExpired = IsInsuranceExpired(reservation.Boat.Insurance.ExpireDate)
                    },
                    Flag = reservation.Boat.Flag,
                    Loa = reservation.Boat.Loa,
                    Beam = reservation.Boat.Beam,
                    Draft = reservation.Boat.Draft,
                    RegistryPort = reservation.Boat.RegistryPort,
                    RegistryNo = reservation.Boat.RegistryNo,
                },
                Captain = new ReservationCaptainReadDto {
                    ReservationId = reservation.ReservationId.ToString(),
                    Id = reservation.Captain.Id,
                    Name = reservation.Captain.Name,
                    Address = reservation.Captain.Address,
                    TaxNo = reservation.Captain.TaxNo,
                    TaxOffice = reservation.Captain.TaxOffice,
                    Phones = reservation.Captain.Phones,
                    Email = reservation.Captain.Email,
                },
                Berths = [.. reservation.Berths.Select(x => new ReservationBerthReadDto {
                    Id = x.Id,
                    ReservationId = x.ReservationId.ToString(),
                    Berth = new SimpleEntity{
                        Id = x.Berth.Id,
                        Description = x.Berth.Description
                    }
                })],
                FromDate = DateHelpers.DateToISOString(reservation.FromDate),
                ToDate = DateHelpers.DateToISOString(reservation.ToDate),
                Days = reservation.Days,
                IsDocked = reservation.IsDocked,
                IsDryDock = reservation.IsDryDock,
                PostAt = reservation.PostAt,
                PostUser = reservation.PostUser,
                PutAt = reservation.PutAt,
                PutUser = reservation.PutUser
            };
        }

        private static bool IsInsuranceExpired(DateTime? date) {
            return date == null || date < DateHelpers.GetLocalDateTime();
        }

    }

}