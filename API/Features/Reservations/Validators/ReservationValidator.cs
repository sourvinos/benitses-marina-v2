using API.Infrastructure.Helpers;
using FluentValidation;

namespace API.Features.Reservations {

    public class ReservationValidator : AbstractValidator<ReservationWriteDto> {

        public ReservationValidator() {
            RuleFor(x => x.FromDate).Must(DateHelpers.BeCorrectFormat);
            RuleFor(x => x.ToDate).Must(DateHelpers.BeCorrectFormat).GreaterThan(x => x.FromDate);
        }

    }

}