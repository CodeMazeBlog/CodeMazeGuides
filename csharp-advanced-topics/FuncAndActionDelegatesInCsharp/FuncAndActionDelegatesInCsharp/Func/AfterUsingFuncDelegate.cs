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

    /// <summary>
    /// In this method, we pass the func delegate as parameter which will be invoked for each user.
    /// </summary>
    /// <param name="email"></param>
    bool SendEmailToAllUsers(Func<string, bool> email)
    {
        var emailStatuses = new List<bool>();
        var userEmails = new List<string> {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            // Func delegate will be invoked here.
            var status = email(userEmail);
            emailStatuses.Add(status);
        }

        return emailStatuses.All(status => status == true);
    }

    /// <summary>
    /// Method to send welcome email to the user
    /// </summary>
    /// <param name="email"></param>
    bool WelcomeEmail(string email)
    {
        Console.WriteLine($"Welcome Email sent to {email}");
        return true;
    }

    /// <summary>
    /// Method to send signup email to the user
    /// </summary>
    /// <param name="email"></param>
    bool SignUpEmail(string email)
    {
        Console.WriteLine($"SignUp Email not sent to {email}");
        return false;
    }
}
