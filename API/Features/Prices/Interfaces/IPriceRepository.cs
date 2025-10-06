using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Prices {

    public interface IPriceRepository : IRepository<Price> {

        IEnumerable<PriceListVM> Get();
        IEnumerable<PriceBrowserListVM> GetForBrowser();
        Task<Price> GetByIdAsync(int id, bool includeTables);
        Task<Price> GetByCodeAsync(string code);

    }

}