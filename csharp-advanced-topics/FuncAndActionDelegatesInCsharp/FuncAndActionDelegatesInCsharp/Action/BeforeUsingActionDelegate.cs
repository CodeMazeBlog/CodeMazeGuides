namespace FuncAndActionDelegatesInCsharp.Action;
public class BeforeUsingActionDelegate
{
    public void SendEmails()
    {
        WelcomeEmail();
        SignUpEmail();
    }

    void WelcomeEmail()
    {
        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            Console.WriteLine($"Sent Welcome Email to {userEmail}");
        }
    }

    void SignUpEmail()
    {
        var userEmails = new List<string>
        {
            "user1@example.com",
            "user2@example.com"
        };

        foreach (var userEmail in userEmails)
        {
            Console.WriteLine($"SignUp Email not sent to {userEmail}");
        }
    }
}
