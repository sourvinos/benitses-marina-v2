using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Features.Boats {

    public class InsuranceValidator : AbstractValidator<BoatInsuranceWriteDto> {

        public InsuranceValidator() {
            RuleFor(x => x.Company).MaximumLength(128);
            RuleFor(x => x.ContractNo).MaximumLength(128);
            RuleFor(x => x.ExpireDate).Must(DateHelpers.BeNullOrCorrectFormat).When(x => x.ExpireDate != null);
        }

    }

}