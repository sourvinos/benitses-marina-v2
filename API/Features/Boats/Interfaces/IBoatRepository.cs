using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Boats {

    public interface IBoatRepository : IRepository<Boat> {

        Task<IEnumerable<BoatListVM>> GetAsync();
        Task<IEnumerable<BoatBrowserVM>> GetForBrowserAsync();
        Task<BoatBrowserVM> GetByIdForBrowserAsync(int id);
        Task<Boat> GetByIdAsync(int id, bool includeTables);

    }

}