namespace FuncAndActionDelegatesInCsharp.Action;
public class AfterUsingActionDelegate
{
    public void SendEmails()
    {
        SendEmailToAllUsers(WelcomeEmail);
        SendEmailToAllUsers(SignUpEmail);
    }


    /// <summary>
    /// In this method, we pass the action delegate as parameter which will be invoked for each user.
    /// </summary>
    /// <param name="email"></param>
    void SendEmailToAllUsers(Action<string> email)
    {
        var userEmails = new List<string> {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            // Action delegate will be invoked here.
            email(userEmail);
        }
    }

    /// <summary>
    /// Method to send welcome email to the user
    /// </summary>
    /// <param name="email"></param>
    void WelcomeEmail(string email)
    {
        Console.WriteLine($"Sent Welcome Email to {email}");
    }

    /// <summary>
    /// Method to send signup email to the user
    /// </summary>
    /// <param name="email"></param>
    void SignUpEmail(string email)
    {
        Console.WriteLine($"SignUp Email not sent to {email}");
    }
}
