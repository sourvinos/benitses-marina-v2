using System.Collections.Generic;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingPostDtoToDomain {

        public static Reservation ReservationPostToDomainDto(ReservationWriteDto reservation) {
            return new Reservation {
                ReservationId = reservation.ReservationId,
                BoatId = reservation.BoatId,
                Captain = new ReservationCaptain {
                    ReservationId = reservation.ReservationId,
                    Name = reservation.Captain.Name,
                    Address = reservation.Captain.Address,
                    TaxNo = reservation.Captain.TaxNo,
                    TaxOffice = reservation.Captain.TaxOffice,
                    Phones = reservation.Captain.Phones,
                    Email = reservation.Captain.Email
                },
                Berths = BuildBerths(reservation),
                FromDate = DateHelpers.StringToDate(reservation.FromDate),
                ToDate = DateHelpers.StringToDate(reservation.ToDate),
                Days = reservation.Days,
                IsPassingBy = reservation.IsPassingBy,
                IsDocked = reservation.IsDocked,
                IsDryDock = reservation.IsDryDock,
                PostAt = reservation.PostAt,
                PostUser = reservation.PostUser,
                PutAt = reservation.PutAt,
                PutUser = reservation.PutUser
            };
        }

        private static List<ReservationBerth> BuildBerths(ReservationWriteDto reservation) {
            var x = new List<ReservationBerth>();
            foreach (var berth in reservation.Berths) {
                var z = new ReservationBerth {
                    Id = berth.Id,
                    ReservationId = reservation.ReservationId,
                    BerthId = berth.BerthId
                };
                x.Add(z);
            }
            return x;
        }

    }

}