using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Prices {

    public interface IPriceValidation : IRepository<Price> {

        Task<int> IsValidAsync(Price x, PriceWriteDto price);

    }

}