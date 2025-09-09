using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API.Features.Reservations {

    public class ReservationValidation(AppDbContext context, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Reservation>(context, httpContext, testingEnvironment, userManager), IReservationValidation {

        public async Task<int> IsValidAsync(Reservation z, ReservationWriteDto reservation) {
            return true switch {
                var x when x == !await IsValidBoatId(reservation) => 452,
                var x when x == IsAlreadyUpdated(z, reservation) => 415,
                _ => 200,
            };
        }

        private async Task<bool> IsValidBoatId(ReservationWriteDto reservation) {
            return reservation.ReservationId.ToString() != ""
                ? await context.Boats.AsNoTracking().FirstOrDefaultAsync(x => x.Id == reservation.BoatId && x.IsActive) != null
                : await context.BoatUsages.AsNoTracking().FirstOrDefaultAsync(x => x.Id == reservation.BoatId) != null;
        }

        private static bool IsAlreadyUpdated(Reservation z, ReservationWriteDto reservation) {
            return z != null && z.PutAt != reservation.PutAt;
        }

    }

}