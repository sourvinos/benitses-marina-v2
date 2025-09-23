using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Features.Boats {

    public class BoatValidator : AbstractValidator<BoatWriteDto> {

        public BoatValidator() {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Flag).NotNull().MaximumLength(128);
            RuleFor(x => x.Loa).NotEmpty().GreaterThanOrEqualTo(0).LessThan(99);
            RuleFor(x => x.Beam).GreaterThanOrEqualTo(0).LessThan(9);
            RuleFor(x => x.Draft).GreaterThanOrEqualTo(0).LessThan(9);
            RuleFor(x => x.RegistryPort).NotNull().MaximumLength(128);
            RuleFor(x => x.RegistryNo).NotNull().MaximumLength(128);
            RuleFor(x => x.Insurance.ExpireDate).Must(DateHelpers.BeNullOrCorrectFormat).When(x => x.Insurance.ExpireDate != null);
            RuleFor(x => x.Insurance.Company).MaximumLength(128);
            RuleFor(x => x.Insurance.ContractNo).MaximumLength(128);
            RuleFor(x => x.FishingLicence.ExpireDate).Must(DateHelpers.BeNullOrCorrectFormat).When(x => x.FishingLicence.ExpireDate != null);
            RuleFor(x => x.FishingLicence.IssuingAuthority).MaximumLength(128);
            RuleFor(x => x.FishingLicence.LicenceNo).MaximumLength(128);
        }

    }

}