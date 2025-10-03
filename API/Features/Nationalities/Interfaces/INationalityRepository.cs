using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Nationalities {

    public interface INationalityRepository : IRepository<Nationality> {

        IEnumerable<NationalityListVM> Get();
        IEnumerable<NationalityBrowserListVM> GetForBrowser();
        Task<Nationality> GetByIdAsync(int id);

    }

}