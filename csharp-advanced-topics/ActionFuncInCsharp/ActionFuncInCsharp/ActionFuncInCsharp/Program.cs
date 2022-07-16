using InvoiceService;

class Program
{
    static void Main(string[] args)
    {
        // initialized invoice service object
        var invoiceService = new InvoicingService();

        // invoice generation example with delegate
        invoiceService.GenerateInvoiceWithDelegate(NotificationProcessor);

        // invoice generation example with action
        invoiceService.GenerateInvoiceWithAction(NotificationProcessor);

        // generate invoice, 1000 is spent and as per
        // provided TaxProcessor it will cost 1200 in total
        invoiceService.GenerateInvoiceWithFunc(1000, TaxProcessor);
    }

    // custom notification processor as per user need
    private static void NotificationProcessor(string input)
    {
        Console.WriteLine(input);
    }

    // Takes total cost spent and process tax logic from caller end
    // and return updated expense
    private static decimal TaxProcessor(decimal input)
    {
        // lets assume we want to apply tax for 20 %
        decimal taxPercentage = 0.20M;
        // lets apply tax to the input amount and return
        return input + (input * taxPercentage);
    }
}
