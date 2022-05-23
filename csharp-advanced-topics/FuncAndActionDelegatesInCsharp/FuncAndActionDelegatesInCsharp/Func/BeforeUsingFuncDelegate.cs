namespace FuncAndActionDelegatesInCsharp.Func;
public class BeforeUsingFuncDelegate
{
    public void SendEmails()
    {
        var welcomeEmailResult = WelcomeEmail();

        if (welcomeEmailResult)
        {
            Console.WriteLine("Sent Welcome Email to all users");
        }

        var signupEmailResult = SignUpEmail();

        if (!signupEmailResult)
        {
            Console.WriteLine("SignUp Email not sent to all users");
        }
        Console.WriteLine();
    }

    bool WelcomeEmail()
    {
        var emailStatuses = new List<bool>();

        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            Console.WriteLine($"Welcome Email sent to {userEmail}");
            emailStatuses.Add(true);
        }

        return emailStatuses.All(status => status == true);
    }

    bool SignUpEmail()
    {
        var emailStatuses = new List<bool>();

        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            Console.WriteLine($"SignUp Email not sent to {userEmail}");
            emailStatuses.Add(false);
        }

        return emailStatuses.All(status => status == true);
    }
}
