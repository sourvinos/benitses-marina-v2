using API.Infrastructure.Interfaces;

namespace API.Features.Boats {

    public interface IBoatValidation : IRepository<BoatWriteDto> {

        int IsValidAsync(Boat x, BoatWriteDto boat);

    }

}