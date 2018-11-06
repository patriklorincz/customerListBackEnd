using FluentValidation;

namespace CustomersList.Models.Dto
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(c => c.Street)
                .Length(0, 100)
                .WithMessage(ValidationMessages.InvalidStreet);

            RuleFor(c => c.Number)
                .Length(0, 100)
                .WithMessage(ValidationMessages.InvalidNumber);

            RuleFor(c => c.Postcode)
                .Length(1, 100)
                .WithMessage(ValidationMessages.InvalidPostcode)
                .NotNull()
                .WithMessage(ValidationMessages.InvalidPostcode);

            RuleFor(c => c.City)
                .Length(0, 100)
                .WithMessage(ValidationMessages.InvalidCity);

            RuleFor(c => c.Country)
                .Length(1, 100)
                .WithMessage(ValidationMessages.InvalidCountry)
                .NotNull()
                .WithMessage(ValidationMessages.InvalidCountry);
        }
    }
}
