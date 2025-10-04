using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Customers.Admin {

    public interface ICustomerRepository : IRepository<Customer> {

        IEnumerable<CustomerListVM> Get();
        IEnumerable<CustomerBrowserListVM> GetForBrowser();
        Task<Customer> GetByIdAsync(int id, bool includeTables);

    }

}