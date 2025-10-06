using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Berths {

    public interface IBerthRepository : IRepository<Berth> {

        IEnumerable<BerthListVM> Get();
        IEnumerable<BerthBrowserListVM> GetForBrowser();
        Task<Berth> GetByIdAsync(int id);

    }

}