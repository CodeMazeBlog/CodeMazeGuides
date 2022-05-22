namespace FuncAndActionDelegatesInCsharp.Action;
public class BeforeUsingActionDelegate
{
    public void SendEmails()
    {
        WelcomeEmail();
        SignUpEmail();
    }

    /// <summary>
    /// Method to send welcome email to all the users
    /// </summary>
    void WelcomeEmail()
    {
        var userEmails = new List<string> {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            // Email sending logic goes here
            Console.WriteLine($"Sent Welcome Email to {userEmail}");
        }
    }

    /// <summary>
    /// Method to send signup email to all the users
    /// </summary>
    void SignUpEmail()
    {
        var userEmails = new List<string> {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            // Email sending logic goes here
            Console.WriteLine($"SignUp Email not sent to {userEmail}");
        }
    }
}
