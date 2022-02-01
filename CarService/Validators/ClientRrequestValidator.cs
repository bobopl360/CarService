using CarService.Models.Requests;
using FluentValidation;

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
