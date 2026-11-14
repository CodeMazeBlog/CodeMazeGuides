using FluentValidation;
using FluentValidation.Validators;

namespace ValidateEmailAddress.Fluent;

public class EmailFluentRegexValidator : AbstractValidator<string>
{
    public EmailFluentRegexValidator()
    {
        RuleFor(email => email)
            .EmailAddress(EmailValidationMode.Net4xRegex);
    }
}
