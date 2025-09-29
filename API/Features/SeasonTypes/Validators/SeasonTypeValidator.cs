using FluentValidation;

namespace API.Features.SeasonTypes {

    public class SeasonTypeValidator : AbstractValidator<SeasonTypeWriteDto> {

        public SeasonTypeValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
        }

    }

}