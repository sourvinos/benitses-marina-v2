using FluentValidation;
using API.Infrastructure.Helpers;

namespace API.Features.Sales {

    public class SaleValidator : AbstractValidator<SaleWriteDto> {

        public SaleValidator() {
            RuleFor(x => x.Date).Must(DateHelpers.BeCorrectFormat);
        }

    }

}
