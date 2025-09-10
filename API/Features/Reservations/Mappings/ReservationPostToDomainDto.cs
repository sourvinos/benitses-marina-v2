using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingPostToDomainDto {

        public static Reservation ReservationPostToDomainDto(ReservationWriteDto reservation) {
            return new Reservation {
                ReservationId = reservation.ReservationId,
                BoatId = reservation.BoatId,
                BoatUser = new ReservationBoatUser {
                    ReservationId = reservation.ReservationId,
                    Name = reservation.BoatUser.Name,
                    Address = reservation.BoatUser.Address,
                    TaxNo = reservation.BoatUser.TaxNo,
                    TaxOffice = reservation.BoatUser.TaxOffice,
                    Phones = reservation.BoatUser.Phones,
                    Email = reservation.BoatUser.Email
                },
                FromDate = DateHelpers.StringToDate(reservation.FromDate),
                ToDate = DateHelpers.StringToDate(reservation.ToDate),
                Days = reservation.Days,
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