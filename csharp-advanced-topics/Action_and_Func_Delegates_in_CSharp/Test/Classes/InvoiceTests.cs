using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Action_and_Func_Delegates_in_CSharp;

namespace Test.Classes
{
    public class InvoiceTests
    {
        [Fact]
        public void Invoice_SaveInvoice_LogsAndSendsEmail()
        {
            // Arrange
            Invoice invoice = new ("F12345", 100.50m);
            string logMessage = "";
            bool emailSent = false;
            void registerLog(string message) => logMessage = message;
            bool emailSend(string subject, string body)
            {
                emailSent = true;
                return true;
            }

            invoice.LogMessageSubscribe(registerLog);
            invoice.SendEmailSubscribe (emailSend);
            invoice.SaveInvoice();

            // Assert
            Assert.Contains("The invoice F12345", logMessage);
            Assert.True(emailSent);
        }
    }
}
