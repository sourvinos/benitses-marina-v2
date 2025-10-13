using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.Items {

    public interface IItemValidation : IRepository<Item> {

        Task<int> IsValidAsync(Item x, ItemWriteDto item);

    }

}