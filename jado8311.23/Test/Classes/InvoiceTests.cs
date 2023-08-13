using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Classes
{
    public class InvoiceTests
    {
        [Fact]
        public void Invoice_SaveInvoice_LogsAndSendsEmail()
        {
            // Arrange
            Invoice invoice = new Invoice("F12345", 100.50m);
            string logMessage = "";
            bool emailSent = false;

            // Act
            invoice.LogMessage += message => logMessage = message;
            invoice.SendEmail += (subject, body) =>
            {
                emailSent = true;
                return true;
            };
            invoice.SaveInvoice();

            // Assert
            Assert.Contains("The invoice F12345", logMessage);
            Assert.True(emailSent);
        }
    }
}
