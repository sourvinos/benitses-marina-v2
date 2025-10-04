using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Customers.Admin {

    public interface ICustomerValidation : IRepository<CustomerWriteDto> {

        Task<int> IsValidAsync(Customer x, CustomerWriteDto customer);

    }

}