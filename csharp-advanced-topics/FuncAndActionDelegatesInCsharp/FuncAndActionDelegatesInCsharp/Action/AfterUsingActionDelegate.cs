namespace FuncAndActionDelegatesInCsharp.Action;
public class AfterUsingActionDelegate
{
    public void SendEmails()
    {
        SendEmailToAllUsers(WelcomeEmail);
        SendEmailToAllUsers(SignUpEmail);
    }

    void SendEmailToAllUsers(Action<string> email)
    {
        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            email(userEmail);
        }
    }

    void WelcomeEmail(string email)
    {
        Console.WriteLine($"Sent Welcome Email to {email}");
    }

    void SignUpEmail(string email)
    {
        Console.WriteLine($"SignUp Email not sent to {email}");
    }
}
