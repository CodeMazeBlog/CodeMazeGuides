namespace FuncAndActionDelegatesInCsharp.Func;
public class AfterUsingFuncDelegate
{
    public void SendEmails()
    {
        var welcomeEmailResult = SendEmailToAllUsers(WelcomeEmail);

        if (welcomeEmailResult)
        {
            Console.WriteLine("Sent Welcome Email to all users");
        }

        var signupEmailResult = SendEmailToAllUsers(SignUpEmail);
        if (!signupEmailResult)
        {
            Console.WriteLine("SignUp Email not sent to all users");
        }
    }

    bool SendEmailToAllUsers(Func<string, bool> email)
    {
        var emailStatuses = new List<bool>();
        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            var status = email(userEmail);
            emailStatuses.Add(status);
        }

        return emailStatuses.All(status => status == true);
    }

    bool WelcomeEmail(string email)
    {
        Console.WriteLine($"Welcome Email sent to {email}");
        return true;
    }

    bool SignUpEmail(string email)
    {
        Console.WriteLine($"SignUp Email not sent to {email}");
        return false;
    }
}
