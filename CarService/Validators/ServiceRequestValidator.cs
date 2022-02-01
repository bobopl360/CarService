using CarService.Models.Requests;
using FluentValidation;

namespace CarService.Validators
{
    public class ServiceRequestValidator : AbstractValidator<ServiceRequest>
    {
        public ServiceRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).NotNull();
            RuleFor(x => x.Type).IsInEnum();

        }
    }
}
