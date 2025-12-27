using FluentValidation;

namespace API.Features.Boats.Admin {

    public class BoatValidator : AbstractValidator<BoatWriteDto> {

        public BoatValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Loa).PrecisionScale(4, 2, false);
            RuleFor(x => x.Beam).PrecisionScale(3, 2, false);
            RuleFor(x => x.Draft).PrecisionScale(3, 2, false);
            RuleFor(x => x.RegistryPort).NotNull().MaximumLength(50);
            RuleFor(x => x.RegistryNo).NotNull().MaximumLength(20);
            RuleFor(x => x.FishingLicence).SetValidator(new FishingLicenceValidator());
            RuleFor(x => x.Insurance).SetValidator(new InsuranceValidator());
        }

    }

}