using System.Threading.Tasks;
using API.Infrastructure.EmailServices;

namespace API.Features.Reservations {

    public interface IReservationEmailSender {

        Task SendReservationToEmail(EmailQueue emailQueue, Reservation reservation);

    }

}