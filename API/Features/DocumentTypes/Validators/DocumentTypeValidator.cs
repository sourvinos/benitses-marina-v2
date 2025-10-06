using FluentValidation;

namespace API.Features.DocumentTypes {

    public class DocumentTypeValidator : AbstractValidator<DocumentTypeWriteDto> {

        public DocumentTypeValidator() {
            RuleFor(x => x.DiscriminatorId).NotNull().InclusiveBetween(1, 4);
            RuleFor(x => x.Abbreviation).NotEmpty().MaximumLength(5);
            RuleFor(x => x.AbbreviationEn).NotEmpty().MaximumLength(5);
            RuleFor(x => x.AbbreviationDataUp).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(128);
            RuleFor(x => x.Batch).NotNull().MaximumLength(5);
            RuleFor(x => x.Customers).NotNull().MaximumLength(1).Matches(@"^[+|\-| ]*$");
        }

    }

}