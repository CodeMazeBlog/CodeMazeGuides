using NUnit.Framework;

namespace Tests
{
    public class InvoiceTests
    {
        [Test]
        public void Invoice_SaveInvoice_LogAndEmailSent()
        {
            // Arrange
            var invoice = new Invoice("F12345", 100.50m);
            bool logMessageCalled = false;
            bool sendEmailCalled = false;

            // Act
            invoice.LogMessage += (message) => logMessageCalled = true;
            invoice.SendEmail += (subject, body) => { sendEmailCalled = true; return true; };
            invoice.SaveInvoice();

            // Assert
            Assert.IsTrue(logMessageCalled, "LogMessage delegate should have been called.");
            Assert.IsTrue(sendEmailCalled, "SendEmail delegate should have been called.");
        }
    }
}
