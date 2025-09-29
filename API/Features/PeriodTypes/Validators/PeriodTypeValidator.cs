using FluentValidation;

namespace API.Features.PeriodTypes {

    public class PeriodTypeValidator : AbstractValidator<PeriodTypeWriteDto> {

        public PeriodTypeValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
        }

    }

}