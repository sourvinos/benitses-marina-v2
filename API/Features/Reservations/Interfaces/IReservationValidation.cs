using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Reservations {

    public interface IReservationValidation : IRepository<Reservation> {

        Task<int> IsValidAsync(Reservation x, ReservationWriteDto reservation);

    }

}