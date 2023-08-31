using FluentEmailExample.Controllers;
using FluentEmailExample.Model;
using FluentEmailExample.Services;
using Moq;

namespace Tests
{
    public class EmailControllerTests
    {
        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendSingleEmailCalled_ThenSendInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendSingleEmail();

            // Assert
            mockEmailService.Verify(x => x.Send(It.IsAny<EmailMetadata>()), Times.Once);
        }

        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendEmailWithRazorTemplateCalled_ThenSendUsingTemplateInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendEmailWithRazorTemplate();

            // Assert
            mockEmailService.Verify(x => x.SendUsingTemplate(It.IsAny<EmailMetadata>(), It.IsAny<string>(), It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendEmailWithLiquidTemplateCalled_ThenSendUsingTemplateInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendEmailWithLiquidTemplate();

            // Assert
            mockEmailService.Verify(x => x.SendUsingTemplate(It.IsAny<EmailMetadata>(), It.IsAny<string>(), It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendEmailWithRazorTemplateFromFileCalled_ThenSendUsingTemplateFromFileInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendEmailWithRazorTemplateFromFile();

            // Assert
            mockEmailService.Verify(x => x.SendUsingTemplateFromFile(It.IsAny<EmailMetadata>(), It.IsAny<string>(), It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendEmailWithAttachmentCalled_ThenSendWithAttachmentInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendEmailWithAttachment();

            // Assert
            mockEmailService.Verify(x => x.SendWithAttachment(It.IsAny<EmailMetadata>()), Times.Once);
        }

        [Fact]
        public async Task GivenFluentEmailConfigured_WhenSendMultipleEmailCalled_ThenSendMultipleInvokedAsync()
        {
            // Arrange
            var mockEmailService = new Mock<IEmailService>();
            var controller = new EmailController(mockEmailService.Object);

            // Act
            await controller.SendMultipleEmails();

            // Assert
            mockEmailService.Verify(x => x.SendMultiple(It.IsAny<List<EmailMetadata>>()), Times.Once);
        }
    }
}