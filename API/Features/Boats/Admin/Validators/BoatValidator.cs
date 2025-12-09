using FluentValidation;

namespace API.Features.Boats.Admin {

    public class BoatValidator : AbstractValidator<BoatWriteDto> {

        public BoatValidator() {    
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Flag).NotNull().MaximumLength(128);
            RuleFor(x => x.Loa).NotEmpty().GreaterThanOrEqualTo(0).LessThan(99);
            RuleFor(x => x.Beam).GreaterThanOrEqualTo(0).LessThan(99);
            RuleFor(x => x.Draft).GreaterThanOrEqualTo(0).LessThan(9);
            RuleFor(x => x.RegistryPort).NotNull().MaximumLength(128);
            RuleFor(x => x.RegistryNo).NotNull().MaximumLength(128);
            RuleFor(x => x.FishingLicence).SetValidator(new FishingLicenceValidator());
            RuleFor(x => x.Insurance).SetValidator(new InsuranceValidator());
        }

    }

}