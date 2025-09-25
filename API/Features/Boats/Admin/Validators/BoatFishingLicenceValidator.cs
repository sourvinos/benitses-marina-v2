using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Features.Boats.Admin {

    public class FishingLicenceValidator : AbstractValidator<BoatFishingLicenceWriteDto> {

        public FishingLicenceValidator() {
            RuleFor(x => x.IssuingAuthority).MaximumLength(128);
            RuleFor(x => x.LicenceNo).MaximumLength(128);
            RuleFor(x => x.ExpireDate).Must(DateHelpers.BeNullOrCorrectFormat).When(x => x.ExpireDate != null);
        }

    }

}