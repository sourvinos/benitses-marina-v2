using System.Collections.Generic;
using System.Linq;

namespace API.Features.Customers.Admin {

    public static class CustomerMappingDomainToListVM {

        public static IEnumerable<CustomerListVM> DomainToListVM(IQueryable<Customer> customers) {
            return [.. customers.Select(x => new CustomerListVM {
                Id = x.Id,
                Description = x.Description,
                IsActive = x.IsActive,
            })];
        }

    }

}