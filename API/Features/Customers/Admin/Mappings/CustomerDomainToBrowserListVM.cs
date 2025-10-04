using System.Collections.Generic;
using System.Linq;

namespace API.Features.Customers.Admin {

    public static class CustomerMappingDomainToBrowserListVM {

        public static IEnumerable<CustomerBrowserListVM> DomainToBrowserListVM(IQueryable<Customer> customers) {
            return [.. customers.Select(x => new CustomerBrowserListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

    }

}