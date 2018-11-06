using FluentValidation;

namespace CustomersList.Models.Dto
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage(ValidationMessages.InvalidEmail)
                .Length(1, 100)
                .WithMessage(ValidationMessages.InvalidEmail);

            RuleFor(c => c.Name)
                .Matches(@"^[a-zA-Z0-9\u00C0-\u024F\-\s']*$")
                .WithMessage(ValidationMessages.InvalidName)
                .NotNull()
                .WithMessage(ValidationMessages.InvalidName)
                .Length(1, 200)
                .WithMessage(ValidationMessages.InvalidName);

            RuleFor(c => c.Website)
                .Length(0, 100)
                .WithMessage(ValidationMessages.InvalidWebsite);

            RuleFor(c => c.Phone)
                .Length(1, 15)
                .WithMessage(ValidationMessages.InvalidPhone)
                .NotNull()
                .WithMessage(ValidationMessages.InvalidPhone)
                .Matches(@"^[0-9]*$")
                .WithMessage(ValidationMessages.InvalidPhone);
            
            RuleFor(c => c.Addresses).SetCollectionValidator(new AddressDtoValidator());
        }
    }
}
