using FluentValidation;

namespace API.Features.Berths {

    public class BerthValidator : AbstractValidator<BerthWriteDto> {

        public BerthValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
        }

    }

}