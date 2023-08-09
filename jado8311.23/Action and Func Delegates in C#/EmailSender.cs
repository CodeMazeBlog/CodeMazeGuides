using System;

public class EmailSender
{
    public static bool SendEmail(string subject, string body)
    {
        // Logic to send the email (simulation)
        Console.WriteLine($"Sending email: {subject}\n{body}");
        return true; // Assuming the email was sent successfully
    }
}