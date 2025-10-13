using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Items {

    public interface IItemRepository : IRepository<Item> {

        IEnumerable<ItemListVM> Get();
        IEnumerable<ItemBrowserListVM> GetForBrowser();
        Task<Item> GetByIdAsync(int id, bool includeTables);
        Task<Item> GetByCodeAsync(string code);

    }

}