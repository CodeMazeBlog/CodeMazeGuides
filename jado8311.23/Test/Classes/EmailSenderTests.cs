using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Classes
{
    public class EmailSenderTests
    {
        [Fact]
        public void EmailSender_SendEmail_ReturnsTrue()
        {
            // Arrange
            string subject = "Test Subject";
            string body = "Test Body";

            // Act
            bool result = EmailSender.SendEmail(subject, body);

            // Assert
            Assert.True(result);
        }
    }
}