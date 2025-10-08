using System.Collections.Generic;
using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.PaymentMethods {

    public interface IPaymentMethodRepository : IRepository<PaymentMethod> {

        IEnumerable<PaymentMethodListVM> Get();
        IEnumerable<PaymentMethodBrowserListVM> GetForBrowser();
        Task<PaymentMethod> GetByIdAsync(int id);

    }

}