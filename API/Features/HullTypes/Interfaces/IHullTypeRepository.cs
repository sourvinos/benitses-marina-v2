using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.HullTypes {

    public interface IHullTypeRepository : IRepository<HullType> {

        Task<IEnumerable<HullTypeListVM>> GetAsync();
        Task<IEnumerable<HullTypeBrowserVM>> GetForBrowserAsync();
        Task<HullTypeBrowserVM> GetByIdForBrowserAsync(int id);
        Task<HullType> GetByIdAsync(int id);

    }

}