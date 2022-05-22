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

    /// <summary>
    /// Method to send welcome email to all the users
    /// </summary>
    bool WelcomeEmail()
    {
        var emailStatuses = new List<bool>();

        var userEmails = new List<string> {
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

    /// <summary>
    /// Method to send signup email to all the users
    /// </summary>
    bool SignUpEmail()
    {
        var emailStatuses = new List<bool>();

        var userEmails = new List<string> {
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
