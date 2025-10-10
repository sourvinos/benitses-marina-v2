using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Berths {

    public interface IBerthValidation : IRepository<Berth> {

        Task<int> IsValidAsync(Berth x, BerthWriteDto berth);

    }

}