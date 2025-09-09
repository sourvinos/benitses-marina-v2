using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingDomainToDto {

        public static ReservationReadDto DomainToDto(Reservation reservation) {
            return new ReservationReadDto {
                ReservationId = reservation.ReservationId,
                Boat = new ReservationBoatReadDto {
                    Id = reservation.Boat.Id,
                    Type = new SimpleEntity {
                        Id = reservation.Boat.Id,
                        Description = reservation.Boat.HullType.Description,
                    },
                    Description = reservation.Boat.Description,
                    Loa = reservation.Boat.Loa,
                    Beam = reservation.Boat.Beam
                },
                User = new SimpleEntity {
                    Id = reservation.BoatUser.Id,
                    Description = reservation.BoatUser.Name,
                },
                FromDate = DateHelpers.DateToISOString(reservation.FromDate),
                ToDate = DateHelpers.DateToISOString(reservation.ToDate),
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