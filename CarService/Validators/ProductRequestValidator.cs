using CarService.Models.Requests;
using FluentValidation;

namespace CarService.Validators
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).NotNull();
        }
    }
}
