namespace ActionandFuncDelegatesinCSharp
{
    public class EmailServiceFuncAndActionExample
    {
        // Func delegate to validate email addresses
        public Func<string, bool> ValidateEmail = (email) =>
        {
            // Simple email validation for demonstration purposes
            return email.Contains("@") && email.Contains(".");
        };

        // Func delegate to generate email content
        public Func<string, string, string> GenerateEmailContent = (recipient, message) =>
        {
            return $"Dear {recipient},\n\n{message}\n\nSincerely,\nEmailService";
        };

        // Action delegate to send an email
        public Action<string, string, string> SendEmail = (recipient, subject, body) =>
        {
            Console.WriteLine($"Sending email to: {recipient}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body:\n{body}");
            Console.WriteLine("Email sent successfully!\n");
        };

        // Method to simulate sending an email using delegates
        public void SendEmailUsingDelegates(string recipient, string subject, string message)
        {
            if (ValidateEmail(recipient))
            {
                string emailContent = GenerateEmailContent(recipient, message);
                SendEmail(recipient, subject, emailContent);
            }
            else
            {
                Console.WriteLine("Invalid email address. Email not sent.\n");
            }
        }
    }
}
