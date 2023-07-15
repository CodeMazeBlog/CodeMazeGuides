namespace MockingWithNSubstitute
{
    public interface IEmailService
    {
        bool SendEmail(string recipient, string subject, string message);
    }
}
