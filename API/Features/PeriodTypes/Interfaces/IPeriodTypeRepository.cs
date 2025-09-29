using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.PeriodTypes {

    public interface IPeriodTypeRepository : IRepository<PeriodType> {

        IEnumerable<PeriodTypeListVM> Get();
        IEnumerable<PeriodTypeBrowserListVM> GetForBrowser();
        Task<PeriodTypeBrowserListVM> GetByIdForBrowserAsync(int id);
        Task<PeriodType> GetByIdAsync(int id);

    }

}