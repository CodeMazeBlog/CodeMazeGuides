using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ValidateEmailAddress.Fluent;

namespace ValidateEmailAddress;
public partial class EmailValidator
{
    private const string EmailPattern =
        @"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

    public bool ValidateUsingMailAddress(string emailAddress)
    {
        try
        {
            var email = new MailAddress(emailAddress);
            return email.Address == emailAddress.Trim();
        }
        catch
        {
            return false;
        }
    }

    public bool ValidateUsingMailAddressTryCreate(string emailAddress)
    {
        return MailAddress.TryCreate(emailAddress, out var email)
            && email.Address == emailAddress.Trim();
    }

    public bool ValidateUsingRegex(string emailAddress)
    {
        var pattern = @"^[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

        var regex = new Regex(pattern);

        return regex.IsMatch(emailAddress);
    }

    [GeneratedRegex(EmailPattern)]
    private static partial Regex EmailRegex();

    public bool ValidateUsingGeneratedRegex(string emailAddress)
    {
        return EmailRegex().IsMatch(emailAddress);
    }

    public bool ValidateUsingFluentValidator(string emailAddress)
    {
        var emailFluentValidator = new EmailFluentValidator();

        var result = emailFluentValidator.Validate(emailAddress);

        return result.IsValid;
    }

    public bool ValidateUsingFluentRegexValidator(string emailAddress)
    {
        var emailFluentRegexValidator = new EmailFluentRegexValidator();

        var result = emailFluentRegexValidator.Validate(emailAddress);

        return result.IsValid;
    }

    public bool ValidateUsingEmailAddressAttribute(string emailAddress)
    {
        var emailValidation = new EmailAddressAttribute();

        return emailValidation.IsValid(emailAddress);
    }
}
