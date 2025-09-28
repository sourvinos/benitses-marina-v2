using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Boats.Admin {

    public interface IBoatRepository : IRepository<Boat> {

        IEnumerable<BoatListVM> Get();
        IEnumerable<BoatBrowserVM> GetForBrowser();
        Task<Boat> GetByIdAsync(int id, bool includeTables);

    }

}