using CarService.Models.Requests;
using FluentValidation;

namespace CarService.Validators
{
    public class ShiftRequestValidator : AbstractValidator<ShiftRequest>
    {
        public ShiftRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
        }
    }
}
