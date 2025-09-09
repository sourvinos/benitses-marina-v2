using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Features.Reservations {

    public class ReservationRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : Repository<Reservation>(appDbContext, httpContext, settings, userManager), IReservationRepository {

        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            var reservations = await context.Reservations
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.HullType)
                .Include(x => x.BoatUser)
                .ToListAsync();
            return ReservationMappingDomainToListVM.DomainToListVM(reservations);
        }

        public async Task<Reservation> GetByIdAsync(string reservationId) {
            return await context.Reservations
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.HullType)
                .Include(x => x.Boat).ThenInclude(x => x.Usage)
                .Include(x => x.BoatUser)
                .Where(x => x.ReservationId.ToString() == reservationId)
                .SingleOrDefaultAsync();
        }


    }

}