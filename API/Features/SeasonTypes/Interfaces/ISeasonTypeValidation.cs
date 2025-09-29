using API.Infrastructure.Interfaces;

namespace API.Features.SeasonTypes {

    public interface ISeasonTypeValidation : IRepository<SeasonType> {

        int IsValid(SeasonType x, SeasonTypeWriteDto seasonType);

    }

}