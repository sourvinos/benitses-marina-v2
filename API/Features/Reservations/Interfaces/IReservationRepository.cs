using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Reservations {

    public interface IReservationRepository : IRepository<Reservation> {

        Task<IEnumerable<ReservationListVM>> GetAsync();
        Task<IEnumerable<ReservationListVM>> GetArrivalsAsync(string date);
        Task<IEnumerable<ReservationListVM>> GetDeparturesAsync(string date);
        Task<Reservation> GetByIdAsync(string reservationId, bool includeTables);
        Task<Reservation> GetByIdForEmailAsync(string reservationId);
        Reservation Update(Guid id, Reservation reservation);

    }

}