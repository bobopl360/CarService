using CarService.Models.Requests;
using FluentValidation;

namespace CarService.Validators
{
    public class EmployeeRequestValidator : AbstractValidator<EmployeeRequest>
    {
        public EmployeeRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.paymentType).IsInEnum();
            RuleFor(x => x.MonthlySalary).NotEmpty().GreaterThan(0).NotNull();
        }
    }
}
