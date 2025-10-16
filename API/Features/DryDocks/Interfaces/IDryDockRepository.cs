using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.DryDocks {

    public interface IDryDockRepository : IRepository<DryDock> {

        IEnumerable<DryDockListVM> Get();
        Task<DryDock> GetByIdAsync(string id, bool includeTables);

    }

}