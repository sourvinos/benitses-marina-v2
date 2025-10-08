using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Sales {

    public interface ISaleValidation : IRepository<Sale> {

        Task<int> IsValidAsync(Sale x, SaleWriteDto sale);

    }

}