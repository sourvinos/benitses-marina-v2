using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.SeasonTypes {

    public interface ISeasonTypeRepository : IRepository<SeasonType> {

        IEnumerable<SeasonTypeListVM> Get();
        IEnumerable<SeasonTypeBrowserListVM> GetForBrowser();
        Task<SeasonType> GetByIdAsync(int id);

    }

}