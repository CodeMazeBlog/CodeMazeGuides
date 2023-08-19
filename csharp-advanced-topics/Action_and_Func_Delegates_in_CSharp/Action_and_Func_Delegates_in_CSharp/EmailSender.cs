namespace Action_and_Func_Delegates_in_CSharp;

public class EmailSender
{
    public static bool SendEmail(string subject, string body)
    {
        // Logic to send the email (simulation)
        Console.WriteLine($"Sending email: {subject}\n{body}");
        return true; // Assuming the email was sent successfully
    }
}
