namespace Action_and_Func_Delegates_in_CSharp;

public class Invoice
{
    // Delegates for logging and email sending
    private Action<string>? LogMessage;
    private Func<string, string, bool>? SendEmail;

    // Invoice data (just an example; in a real application, there would be more properties)
    public string InvoiceNumber { get; set; }
    public decimal TotalAmount { get; set; }

    public Invoice(string invoiceNumber, decimal totalAmount)
    {
        InvoiceNumber = invoiceNumber;
        TotalAmount = totalAmount;
    }

    public void LogMessageSubscribe(Action<string>? logMessage)
    {
        if (logMessage == null)
        {
            throw new ArgumentNullException(nameof(logMessage));
        }

        LogMessage += logMessage;
    }

    public void SendEmailSubscribe(Func<string, string, bool>? sendEmail)
    {
        if (sendEmail == null)
        {
            throw new ArgumentNullException(nameof(sendEmail));
        }

        SendEmail += sendEmail;
    }

    public void SaveInvoice()
    {
        // Logic to save the invoice (implementation omitted for simplicity)
        // ...

        // Register a message in the log using the LogMessage delegate
        LogMessage?.Invoke($"The invoice {InvoiceNumber} with a total amount of {TotalAmount} has been saved.");

        // Send an email using the SendEmail delegate
        string message = $"The invoice {InvoiceNumber} with a total amount of {TotalAmount} has been saved.";
        bool emailSent = SendEmail?.Invoke("Invoice Saved", message) ?? false;

        // If the email was sent successfully, we can perform some additional actions if necessary
        if (emailSent)
        {
            // Perform some additional actions if needed
            // ...
        }
    }
}
