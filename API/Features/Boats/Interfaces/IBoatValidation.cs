using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Boats {

    public interface IBoatValidation : IRepository<BoatWriteDto> {

        Task<int> IsValidAsync(Boat x, BoatWriteDto boat);

    }

}