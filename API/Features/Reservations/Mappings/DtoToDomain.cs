using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingDtoToDomain {

        public static Reservation DtoToDomain(ReservationWriteDto reservation) {
            var x = new Reservation {
                ReservationId = reservation.ReservationId,
                BoatId = reservation.BoatId,
                BoatOwner = new ReservationBoatOwner {
                    ReservationId = reservation.ReservationId,
                    Name = reservation.BoatOwner.Name,
                    Address = reservation.BoatOwner.Address,
                    TaxNo = reservation.BoatOwner.TaxNo,
                    TaxOffice = reservation.BoatOwner.TaxOffice,
                    Phones = reservation.BoatOwner.Phones,
                    Email = reservation.BoatOwner.Email
                },
                FromDate = DateHelpers.StringToDate(reservation.FromDate),
                ToDate = DateHelpers.StringToDate(reservation.ToDate),
                IsDocked = reservation.IsDocked,
                IsDryDock = reservation.IsDryDock,
                PostAt = reservation.PostAt,
                PostUser = reservation.PostUser,
                PutAt = reservation.PutAt,
                PutUser = reservation.PutUser
            };
            return x;
        }

    }

}