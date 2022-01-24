using CarService.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Validators
{
    public class CarRequestValidator : AbstractValidator<CarsRequest>
    {
        public CarRequestValidator()
        {
            RuleFor(x => x.Make).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Model).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.Fuel).IsInEnum();

        }
    }
}
