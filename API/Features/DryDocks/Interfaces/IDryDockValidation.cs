using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.DryDocks {

    public interface IDryDockValidation : IRepository<DryDock> {

        Task<int> IsValidAsync(DryDock x, DryDockWriteDto writeDto);

    }

}