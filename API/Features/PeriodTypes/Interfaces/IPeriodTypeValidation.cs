using API.Infrastructure.Interfaces;

namespace API.Features.PeriodTypes {

    public interface IPeriodTypeValidation : IRepository<PeriodType> {

        int IsValid(PeriodType x, PeriodTypeWriteDto periodType);

    }

}