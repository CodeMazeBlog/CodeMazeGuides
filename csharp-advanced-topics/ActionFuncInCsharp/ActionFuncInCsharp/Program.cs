using InvoiceService;

class Program
{
    static void Main(string[] args)
    {
        var invoiceService = new InvoicingService();
        invoiceService.GenerateInvoiceWithDelegate(NotificationProcessor);
        invoiceService.GenerateInvoiceWithAction(NotificationProcessor);
        invoiceService.GenerateInvoiceWithFunc(1000, TaxProcessor);
    }
    private static void NotificationProcessor(string input)
    {
        Console.WriteLine(input);
    }
    private static decimal TaxProcessor(decimal input)
    {
        var taxPercentage = 0.20M;
        return input + (input * taxPercentage);
    }
}
