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
using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace API.Features.Reservations {

    public class ReservationRepository(AppDbContext appDbContext, IHttpContextAccessor httpContext, IOptions<TestingEnvironment> testingEnvironment, UserManager<UserExtended> userManager) : Repository<Reservation>(appDbContext, httpContext, testingEnvironment, userManager), IReservationRepository {

        private readonly TestingEnvironment testingEnvironment = testingEnvironment.Value;

        public async Task<IEnumerable<ReservationListVM>> GetAsync() {
            var reservations = await context.Reservations
                .AsNoTracking()
                .Include(x => x.Boat).ThenInclude(x => x.HullType)
                .Include(x => x.Captain)
                .Include(x => x.Berths).ThenInclude(x => x.Berth)
                .ToListAsync();
            return ReservationMappingReadDomainToListVM.ReservationDomainToListVM(reservations);
        }

        public async Task<Reservation> GetByIdAsync(string reservationId, bool includeTables) {
            return includeTables
                ? await context.Reservations
                    .AsNoTracking()
                    .Include(x => x.Boat).ThenInclude(x => x.HullType)
                    .Include(x => x.Boat).ThenInclude(x => x.Usage)
                    .Include(x => x.Captain)
                    .Include(x => x.Berths).ThenInclude(x => x.Berth)
                    .Where(x => x.ReservationId.ToString() == reservationId)
                    .SingleOrDefaultAsync()
               : await context.Reservations
                  .AsNoTracking()
                  .Where(x => x.ReservationId.ToString() == reservationId)
                  .SingleOrDefaultAsync();
        }

        public Reservation Update(Guid reservationId, Reservation reservation) {
            using var transaction = context.Database.BeginTransaction();
            UpdateReservation(reservation);
            UpdateBerths(reservationId, reservation);
            context.SaveChanges();
            DisposeOrCommit(transaction);
            return reservation;
        }

        private void UpdateReservation(Reservation reservation) {
            context.Reservations.Update(reservation);
        }

        private void UpdateBerths(Guid reservationId, Reservation reservation) {
            var existingBerths = context.ReservationBerths
                .AsNoTracking()
                .Where(x => x.ReservationId == reservationId)
                .ToList();
            var berthsToUpdate = reservation.Berths
                .Where(x => x.Id != 0)
                .ToList();
            var berthsToDelete = existingBerths
                .Except(berthsToUpdate, new BerthComparerById())
                .ToList();
            context.ReservationBerths.RemoveRange(berthsToDelete);
        }

        private class BerthComparerById : IEqualityComparer<ReservationBerth> {
            public bool Equals(ReservationBerth x, ReservationBerth y) {
                return x.Id == y.Id;
            }
            public int GetHashCode(ReservationBerth x) {
                return x.Id.GetHashCode();
            }
        }

        private void DisposeOrCommit(IDbContextTransaction transaction) {
            if (testingEnvironment.IsTesting) {
                transaction.Dispose();
            } else {
                transaction.Commit();
            }
        }

    }

}