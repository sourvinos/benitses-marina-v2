using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;

namespace API.Features.Reservations {

    public static class ReservationDomainToListVM {

        public static IEnumerable<ReservationListVM> Read(IQueryable<Reservation> reservations) {
            return [.. reservations.Select(x => new ReservationListVM {
                ReservationId = x.ReservationId,
                Boat = new ReservationListBoatVM {
                    Id = x.Boat.Id,
                    Type = new SimpleEntity {
                        Id = x.Boat.HullType.Id,
                        Description = x.Boat.HullType.Description
                    },
                    Description = x.Boat.Description,
                    Loa = x.Boat.Loa,
                    Beam = x.Boat.Beam
                },
                Berths = x.Berths.Select(x => new ReservationListBerthVM {
                    Id = x.Berth.Id,
                    ReservationId = x.ReservationId.ToString(),
                    Berth = new SimpleEntity {
                        Id = x.Berth.Id,
                        Description = x.Berth.Description
                    }
                }),
                FromDate = DateHelpers.DateToISOString(x.FromDate),
                ToDate = DateHelpers.DateToISOString(x.ToDate),
                Days = x.ToDate.Subtract(x.FromDate).Days,
                IsPassingBy = x.IsPassingBy,
                IsDocked = x.IsDocked,
                IsDryDock = x.IsDryDock
            })];
        }

    }

}