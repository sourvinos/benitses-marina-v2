using API.Infrastructure.Interfaces;

namespace API.Features.Berths {

    public interface IBerthValidation : IRepository<Berth> {

        int IsValid(Berth x, BerthWriteDto berth);

    }

}