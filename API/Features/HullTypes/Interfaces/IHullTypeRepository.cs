using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.HullTypes {

    public interface IHullTypeRepository : IRepository<HullType> {

        IEnumerable<HullTypeListVM> Get();
        IEnumerable<HullTypeBrowserVM> GetForBrowser();
        Task<HullType> GetByIdAsync(int id);

    }

}