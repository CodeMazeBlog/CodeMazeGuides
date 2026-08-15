namespace QuartzVsHangfire.Services;

public interface IEmailSender
{
    Task SendWelcomeAsync(int userId);
}
