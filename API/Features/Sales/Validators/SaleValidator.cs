using FluentValidation;

namespace API.Features.Sales {

    public class SaleValidator : AbstractValidator<SaleWriteDto> {

        public SaleValidator() {
            RuleFor(x => x.NetAmount + x.VatAmount).LessThan(99999).WithMessage("Gross amount must be less than 99999");
        }

    }

}
