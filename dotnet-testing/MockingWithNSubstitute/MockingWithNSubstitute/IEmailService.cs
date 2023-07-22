namespace MockingWithNSubstitute;

public interface IEmailService
{
    bool IsValidEmail(string email);
    bool SendEmail(string recipient, string subject, string message);
}
