using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.TaxOffices {

    public interface ITaxOfficeRepository : IRepository<TaxOffice> {

        IEnumerable<TaxOfficeListVM> Get();
        IEnumerable<TaxOfficeBrowserListVM> GetForBrowser();
        Task<TaxOffice> GetByIdAsync(int id);

    }

}