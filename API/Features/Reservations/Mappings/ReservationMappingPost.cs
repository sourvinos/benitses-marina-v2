using System.Linq;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingPost {

        public static Reservation Write(ReservationWriteDto reservation) {
            return new Reservation {
                ReservationId = reservation.ReservationId,
                BoatId = reservation.BoatId,
                // Captain = new ReservationCaptain {
                //     ReservationId = reservation.ReservationId,
                //     Name = reservation.Captain.Name,
                //     Address = reservation.Captain.Address,
                //     TaxNo = reservation.Captain.TaxNo,
                //     TaxOffice = reservation.Captain.TaxOffice,
                //     Phones = reservation.Captain.Phones,
                //     Email = reservation.Captain.Email
                // },
                Berths = [.. reservation.Berths.Select(x => new ReservationBerth {
                    Id = x.Id,
                    BerthId = x.BerthId,
                })],
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

    }

}