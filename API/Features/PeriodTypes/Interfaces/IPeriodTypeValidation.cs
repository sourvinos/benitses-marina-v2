using System.Threading.Tasks;
using API.Infrastructure.Interfaces;

namespace API.Features.PeriodTypes {

    public interface IPeriodTypeValidation : IRepository<PeriodType> {

        Task<int> IsValidAsync(PeriodType x, PeriodTypeWriteDto periodType);

    }

}