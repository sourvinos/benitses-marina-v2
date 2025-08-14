using FluentValidation;

namespace API.Features.HullTypes {

    public class HullTypeValidator : AbstractValidator<HullTypeWriteDto> {

        public HullTypeValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
        }

    }

}