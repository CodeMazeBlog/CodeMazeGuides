namespace InvoiceService
{
    public class InvoicingService
    {
        public delegate void ProcessNotification(string body);
        public void GenerateInvoiceWithDelegate(ProcessNotification? notificationProcessor = null)
        {
            if (notificationProcessor != null)
            {
                var notificationBody = "Generic Notifcation Body";
                notificationProcessor(notificationBody);
            }
        }
        public void GenerateInvoiceWithAction(Action<string>? notificationProcessor = null)
        {
            if (notificationProcessor != null)
            {
                var notificationBody = "Generic Notifcation Body";
                notificationProcessor(notificationBody);
            }
        }
        public void GenerateInvoiceWithFunc(decimal totalSpending, Func<decimal, decimal>? taxCalculation = null)
        {
            if (taxCalculation != null)
            {
                totalSpending = taxCalculation(totalSpending);
                // next generation and uploading of invoice in artifacts storage or database etc
            }
        }
    }
}