using CarService.Models.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Validators
{
    public class ClientRrequestValidator : AbstractValidator<ClientRequest>
    {
        public ClientRrequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(2).MaximumLength(10);
            RuleFor(x => x.PaymentType).IsInEnum();

        }
    }
}
