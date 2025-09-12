using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Berths {

    public interface IBerthRepository : IRepository<Berth> {

        Task<IEnumerable<BerthListVM>> GetAsync();
        Task<IEnumerable<BerthBrowserVM>> GetForBrowserAsync();
        Task<BerthBrowserVM> GetByIdForBrowserAsync(int id);
        Task<Berth> GetByIdAsync(int id);

    }

}