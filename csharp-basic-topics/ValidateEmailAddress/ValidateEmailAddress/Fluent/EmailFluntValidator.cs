using FluentValidation;
using FluentValidation.Validators;

namespace ValidateEmailAddress.Fluent;

public class EmailFluentValidator : AbstractValidator<string>
{
    public EmailFluentValidator()
    {
        RuleFor(email => email)
            .EmailAddress(EmailValidationMode.Net4xRegex);
    }
}
