using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.Infrastructure.Helpers;
using System;

namespace API.Features.Reservations {

    public class ReservationValidation(AppDbContext context, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Reservation>(context, httpContext, testingEnvironment, userManager), IReservationValidation {

        public async Task<int> IsValidAsync(Reservation z, ReservationWriteDto reservation) {
            return true switch {
                var x when x == !await IsValidBerthId(reservation) => 454,
                var x when x == !await IsValidBoatId(reservation) => 452,
                var x when x == AreDaysCorrect(reservation) => 453,
                var x when x == IsAlreadyUpdated(z, reservation) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBerthId(ReservationWriteDto reservation) {
            if (reservation.Berths.Count != 0) {
                bool isValid = false;
                foreach (var berth in reservation.Berths) {
                    if (reservation.ReservationId == Guid.Empty) {
                        isValid = await context.Berths
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == berth.BerthId && x.IsActive) != null;
                        if (!isValid) return isValid;
                    } else {
                        isValid = await context.Berths
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == berth.BerthId) != null;
                        if (!isValid) return isValid;
                    }
                }
                return reservation.Berths.Count == 0 || isValid;
            }
            return true;
        }

        private async Task<bool> IsValidBoatId(ReservationWriteDto reservation) {
            return reservation.ReservationId.ToString() != ""
                ? await context.Boats.AsNoTracking().FirstOrDefaultAsync(x => x.Id == reservation.BoatId && x.IsActive) != null
                : await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == reservation.BoatId) != null;
        }

        private static bool AreDaysCorrect(ReservationWriteDto reservation) {
            var actualDays = DateHelpers.StringToDate(reservation.ToDate) - DateHelpers.StringToDate(reservation.FromDate);
            return reservation.Days != actualDays.Days;
        }

        private static bool IsAlreadyUpdated(Reservation z, ReservationWriteDto reservation) {
            return z != null && z.PutAt != reservation.PutAt;
        }

    }

}