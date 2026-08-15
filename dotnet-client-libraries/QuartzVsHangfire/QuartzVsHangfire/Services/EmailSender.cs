namespace QuartzVsHangfire.Services;

public class EmailSender : IEmailSender
{
    public Task SendWelcomeAsync(int userId)
    {
        Console.WriteLine($"Sending welcome email to user {userId}.");

        return Task.CompletedTask;
    }
}
