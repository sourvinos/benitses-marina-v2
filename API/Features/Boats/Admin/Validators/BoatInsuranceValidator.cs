using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Features.Boats.Admin {

    public class InsuranceValidator : AbstractValidator<BoatInsuranceWriteDto> {

        public InsuranceValidator() {
            RuleFor(x => x.Company).MaximumLength(100);
            RuleFor(x => x.ContractNo).MaximumLength(50);
            RuleFor(x => x.ExpireDate).Must(DateHelpers.BeNullOrCorrectFormat).When(x => x.ExpireDate != null);
        }

    }

}