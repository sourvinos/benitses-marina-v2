using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationMappingDomainToListVM {

        public static List<ReservationListVM> DomainToListVM(List<Reservation> reservations) {
            var x = reservations.Select(x => new ReservationListVM {
                ReservationId = x.ReservationId,
                Boat = new ReservationBoatReadDto {
                    Id = x.Boat.Id,
                    Type = new SimpleEntity {
                        Id = x.Boat.Type.Id,
                        Description = x.Boat.Type.Description
                    },
                    Description = x.Boat.Description,
                    Loa = x.Boat.Loa,
                    Beam = x.Boat.Beam
                },
                FromDate = DateHelpers.DateToISOString(x.FromDate),
                ToDate = DateHelpers.DateToISOString(x.ToDate),
                IsDocked = x.IsDocked,
                IsDryDock = x.IsDryDock
            }).ToList();
            return x;
        }

    }

}