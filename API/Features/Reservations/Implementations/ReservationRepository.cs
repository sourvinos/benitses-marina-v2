using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Users;
using API.Infrastructure.Classes;
using API.Infrastructure.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Reservations {

    public class ReservationRepository : Repository<Reservation>, IReservationRepository {

        public ReservationRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> settings, UserManager<UserExtended> userManager) : base(appDbContext, httpContext, settings, userManager) { }

        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            var reservations = await context.Reservations
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.Type)
                .ToListAsync();
            return ReservationMappingDomainToListVM.DomainToListVM(reservations);
        }

    }

}