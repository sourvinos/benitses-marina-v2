using FluentValidation;

namespace API.Features.Boats {

    public class BoatValidator : AbstractValidator<BoatWriteDto> {

        public BoatValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Flag).NotEmpty().MaximumLength(128);
        }

    }

}