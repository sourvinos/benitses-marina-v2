using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.BoatUsages {

    public interface IBoatUsageRepository : IRepository<BoatUsage> {

        IEnumerable<BoatUsageListVM> Get();
        IEnumerable<BoatUsageBrowserVM> GetForBrowser();
        Task<BoatUsageBrowserVM> GetByIdForBrowserAsync(int id);
        Task<BoatUsage> GetByIdAsync(int id);

    }

}