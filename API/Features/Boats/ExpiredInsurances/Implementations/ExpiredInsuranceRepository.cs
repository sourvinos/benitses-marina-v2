using System;
using System.Collections.Generic;
using System.Linq;
using API.Infrastructure.Classes;
using API.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Boats.Insurances {

    public class ExpiredInsuranceRepository(AppDbContext appDbContext) : IExpiredInsuranceRepository {

        private readonly AppDbContext appDbContext = appDbContext;

        public IEnumerable<ExpiredInsuranceVM> GetExpiredInsurances() {
            return appDbContext.Reservations
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.Insurance)
                .Where(x => x.IsDocked && (x.Boat.Insurance.ExpireDate <= DateHelpers.GetLocalDateTime() || x.Boat.Insurance.ExpireDate == null))
                .Select(x => new ExpiredInsuranceVM {
                    Boat = new ExpiredInsuranceBoatVM {
                        BoatId = x.Boat.Id,
                        Description = x.Boat.Description,
                        IsAthenian = x.Boat.IsAthenian,
                        IsFishingBoat = x.Boat.IsFishingBoat,
                        InsuranceExpireDate = x.Boat.Insurance.ExpireDate != null ? DateHelpers.DateToISOString((DateTime)(x.Boat.Insurance.ExpireDate ?? null)) : ""
                    },
                    Reservation = new ExpiredInsuranceReservationVM {
                        ReservationId = x.ReservationId.ToString(),
                        FromDate = DateHelpers.DateToISOString(x.FromDate),
                        ToDate = DateHelpers.DateToISOString(x.ToDate),
                    }
                });
        }

    }

}
