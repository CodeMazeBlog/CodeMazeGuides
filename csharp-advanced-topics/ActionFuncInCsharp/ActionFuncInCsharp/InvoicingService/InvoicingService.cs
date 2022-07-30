namespace InvoiceService
{
    public class InvoicingService
    {
        // declaration of delegate for notification processing
        public delegate void ProcessNotification(string body);

        // Method to genarate invoice and also facilitates to control 
        // how you want to send notifications
        public void GenerateInvoiceWithDelegate(ProcessNotification? notificationProcessor = null)
        {
            // generation processing
            // lets assume there is logic to generate invoice
            // uploading of invoice in artifacts storage or database etc

            // now at the end, notification processing
            if (notificationProcessor != null)
            {
                // sample notification body
                var notificationBody = "Generic Notifcation Body";
                // delegate notification processing to the caller end
                notificationProcessor(notificationBody);
            }
        }

        // Method to genarate invoice and also facilitates to control 
        // how you want to send notifications
        public void GenerateInvoiceWithAction(Action<string>? notificationProcessor = null)
        {
            // generation processing
            // lets assume there is logic to generate invoice
            // uploading of invoice in artifacts storage or database etc

            // now at the end, notification processing through Action<string>
            if (notificationProcessor != null)
            {
                // sample notification body
                var notificationBody = "Generic Notifcation Body";
                // delegate notification processing to the caller end
                notificationProcessor(notificationBody);
            }
        }

        // Method to genarate invoice and also facilitates to control 
        // how you want to calculate tax
        public void GenerateInvoiceWithFunc(decimal totalSpending, Func<decimal, decimal>? taxCalculation = null)
        {
            // generation processing
            // lets assume there is logic to generate invoice
            // 

            // now calculate tax through Func<decimal,decimal> delegate
            if (taxCalculation != null)
            {
                // delegate tax processing to the caller end, and update 
                // total spending, which will be further passed into invoice
                // generation logic
                totalSpending = taxCalculation(totalSpending);

                // compile invoice
                // uploading of invoice in artifacts storage or database etc
            }
        }
    }
}