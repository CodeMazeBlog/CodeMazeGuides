using FluentValidation;

namespace ValidateEmailAddress.Fluent;

public class EmailFluentValidator : AbstractValidator<string>
{
    public EmailFluentValidator()
    {
        RuleFor(email => email)
            .EmailAddress();
    }
}
