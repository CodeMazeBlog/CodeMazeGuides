using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Hello, this is the starting point of our application!");

        // Create an instance of the Invoice class
        Invoice invoice = new Invoice("F12345", 100.50m);

        // Subscribe the Log method from the LogManager class to the LogMessage delegate
        invoice.LogMessage += LogManager.Log;

        // Subscribe the SendEmail method from the EmailSender class to the SendEmail delegate
        invoice.SendEmail += EmailSender.SendEmail;

        // Save the invoice, which will trigger the subscribed delegates
        invoice.SaveInvoice();
    }
}
