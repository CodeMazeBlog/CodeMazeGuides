using Moq;
using System.Text;

namespace TestsDelegateFuncAppSample;

public class ProcessingTests
{
    [Fact]
    public void ProcessListMessages_WhenCalled_CallsCorrectNotificationService()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        var processed = mockSenderProcess.Object.Processed;
        var records = new List<Messages>
        {
            new() { TypeMessage = (int)TypeMessageEnum.WhatsApp, Recipient = "Recipient1", Message = "Message1", Email = "email1@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = (int)TypeMessageEnum.Sms, Recipient = "Recipient2", Message = "Message2", Email = "email2@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = (int)TypeMessageEnum.Email, Recipient = "Recipient3", Message = "Message3", Email = "email3@contoso.com", PhoneNumber = "1234567890" }
        };
        // Act
        mockSenderProcess.Object.ProcessListMessages(records, mockNotificationService.Object, processed);
        // Assert
        Assert.Equal(1, mockNotificationService.Object.CountTypes[0]);
        Assert.Equal(1, mockNotificationService.Object.CountTypes[1]);
        Assert.NotEqual(0, mockNotificationService.Object.CountTypes[2]);

    }

    [Fact]
    public void ProcessListMessages_WithEmptyList_DoesNotCallNotificationService()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        var processed = mockSenderProcess.Object.Processed;
        var records = new List<Messages>();
        // Act
        mockSenderProcess.Object.ProcessListMessages(records, mockNotificationService.Object, processed);
        // Assert
        Assert.Equal(0, mockNotificationService.Object.CountTypes[0]);
        Assert.Equal(0, mockNotificationService.Object.CountTypes[1]);
        Assert.NotEqual(1, mockNotificationService.Object.CountTypes[2]);
    }

    [Fact]
    public void ProcessListMessages_WhenCalled_ExpectedCountForWrongTypeMessage()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        var processed = mockSenderProcess.Object.Processed;
        var records = new List<Messages>
        {
            new() { TypeMessage = 4, Recipient = "Recipient1", Message = "Message1", Email = "email1@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = 5, Recipient = "Recipient2", Message = "Message2", Email = "email2@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = (int)TypeMessageEnum.WhatsApp, Recipient = "Recipient3", Message = "Message3", Email = "email3@contoso.com", PhoneNumber = "1234567890" }
        };
        // Act
        mockSenderProcess.Object.ProcessListMessages(records, mockNotificationService.Object, processed);
        // Assert
        Assert.Equal(1, mockNotificationService.Object.CountTypes[(int)TypeMessageEnum.WhatsApp]);
        Assert.Equal(0, mockNotificationService.Object.CountTypes[(int)TypeMessageEnum.Sms]);
        Assert.NotEqual(1, mockNotificationService.Object.CountTypes[(int)TypeMessageEnum.Email]);
    }

    [Fact]
    public void ProcessListMessages_WhenCalled_CorrectlyReturnCountTypes()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        var processed = mockSenderProcess.Object.Processed; 

        var records = new List<Messages>
        {
            new() { TypeMessage = (int)TypeMessageEnum.WhatsApp, Recipient = "Recipient1", Message = "Message1", Email = "email1@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = (int)TypeMessageEnum.Sms, Recipient = "Recipient2", Message = "Message2", Email = "email2@contoso.com", PhoneNumber = "1234567890" },
            new() { TypeMessage = (int)TypeMessageEnum.Email, Recipient = "Recipient3", Message = "Message3", Email = "email3@contoso.com", PhoneNumber = "1234567890" }
        };

        // Act
        mockSenderProcess.Object.ProcessListMessages(records, mockNotificationService.Object, processed);
        // Assert
        Assert.NotEqual(0, mockNotificationService.Object.CountTypes[0]);
        Assert.Equal(1, mockNotificationService.Object.CountTypes[1]);
        Assert.Equal(1, mockNotificationService.Object.CountTypes[2]);
    }

    [Fact]
    public void ProcessFile_WhenCalled_ThrowExceptionWhenBadFileFormat()
    {
        // Arrange
        const string pTestFilePath = "test1.csv";
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        var processed = mockSenderProcess.Object.Processed;
        
        const string pContenFile =
                """
                XType,XRecipient,XMessage,XEmail,XPhoneNumber
                1,SSDAJDQA,DNSADQDASODFAD,NQU9WERQUERQJNJ,RSAFAASNMA
                8932389143J4JK23KL4QRNMADM,AMDAMSDNA,SMDA,DM,AS
                """;

        File.WriteAllText(pTestFilePath, pContenFile);

        // Act
        var ex = Assert.Throws<Exception>(() => mockSenderProcess.Object.ProcessFile(pTestFilePath, mockNotificationService.Object));

        // Assert
        Assert.Contains("Error on row: 2", ex.Message);
        File.Delete(pTestFilePath);
    }

    [Fact]
    public void ProcessFile_WhenCalled_IncorrectRowType()
    {
        // Arrange
        const string pTestFilePath = "test0.csv";
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();

        const string pContenFile =
                """
                Type,Recipient,Message,Email,PhoneNumber
                0,Recipient1,Message1,email1@contoto.com,1234567890
                1,Recipient2,Message2,email2@contoto.com,1234567890
                4,Recipient3,Message3,email3@contoto.com,1234567890
                1,Recipient4,Message4,email4@contoto.com,1234567890
                """;

        File.WriteAllText(pTestFilePath, pContenFile);

        // Act
        var ex = Assert.Throws<Exception>(() => mockSenderProcess.Object.ProcessFile(pTestFilePath, mockNotificationService.Object));

        // Assert
        Assert.Contains("Error on row: 3", ex.Message);
        File.Delete(pTestFilePath);
    }

    //An error occurred while processing list: Invalid TypeMessage, row: 2

    [Fact]
    public void ProcessFile_WhenCalled_ReturnCorrectNotificationServiceCountType()
    {
        const string pTestFilePath = "test.csv";

        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();

        File.WriteAllText(pTestFilePath, "Type,Recipient,Message,Email,PhoneNumber\n0,Recipient1,Message1,email1@contoto.com,1234567890\n2,Recipient3,Message3,email3@contoto.com,1234567890");
        // Act
        mockSenderProcess.Object.ProcessFile(pTestFilePath, mockNotificationService.Object);
        // Assert
        Assert.Equal(1, mockNotificationService.Object.CountTypes[0]);
        Assert.NotEqual(1, mockNotificationService.Object.CountTypes[1]);
        Assert.Equal(0, mockNotificationService.Object.CountTypes[1]);
        Assert.Equal(1, mockNotificationService.Object.CountTypes[2]);
        // Clean up
        File.Delete(pTestFilePath);
    }

    [Fact]
    public void ProcessFile_WithInvalidPath_ReturnsNull()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        const string pTestFilePath = "testFileNotExists.csv";
        // Act
        var result = mockSenderProcess.Object.ProcessFile(pTestFilePath, mockNotificationService.Object);
        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Processed_WhenCalled_ReturnsCorrectValue()
    {
        // Arrange
        var mockNotificationService = new Mock<SendNotifications>();
        var mockSenderProcess = new Mock<SenderProcess>();
        const int typeMessage = (int)TypeMessageEnum.WhatsApp;
        const int expectedCount = 1;
        // Act
        mockSenderProcess.Object.Processed(typeMessage, mockNotificationService.Object);
        // Assert
        Assert.Equal(expectedCount, mockNotificationService.Object.CountTypes[typeMessage]);
    }

    [Fact]
    public void WhatsAppSender_Send_WhenCalled_WritesToConsole()
    {
        // Arrange
        var whatsAppSender = new WhatsAppSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = (int)TypeMessageEnum.WhatsApp
        };
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        // Act
        whatsAppSender.Send(message);
        // Assert
        Assert.Contains("Sending WhatsApp message to Recipient1: Message1", consoleOutput.ToString());
    }

    [Fact]
    public void WhatsAppSender_Send_WhenCalledWithWrongType_ThrowsException()
    {
        // Arrange
        var whatsAppSender = new WhatsAppSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = 3 // wrong type
        };
        // Act & Assert
        Assert.Throws<Exception>(() => whatsAppSender.Send(message));
    }

    [Fact]
    public void SmsSender_Send_WhenCalled_WritesToConsole()
    {
        // Arrange
        var smsSender = new SmsSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = 1
        };
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        // Act
        smsSender.Send(message);
        // Assert
        Assert.Contains("Sending SMS to Recipient1: Message1", consoleOutput.ToString());
    }

    [Fact]
    public void SmsSender_Send_WhenCalledWithWrongType_ThrowsException()
    {
        // Arrange
        var smsSender = new SmsSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = 0 // wrong type
        };
        // Act & Assert
        Assert.Throws<Exception>(() => smsSender.Send(message));
    }

    [Fact]
    public void EmailSender_Send_WhenCalled_WritesToConsole()
    {
        // Arrange
        var emailSender = new EmailSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = 2
        };
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        // Act
        emailSender.Send(message);
        // Assert
        Assert.Contains("Sending Email to Recipient1: Message1", consoleOutput.ToString());
    }

    [Fact]
    public void EmailSender_Send_WhenCalledWithWrongType_ThrowsException()
    {
        // Arrange
        var emailSender = new EmailSender();
        var message = new Messages
        {
            Recipient = "Recipient1",
            Message = "Message1",
            Email = "email1@contoso.com",
            PhoneNumber = "1234567890",
            TypeMessage = 3 // wrong type
        };
        // Act & Assert
        Assert.Throws<Exception>(() => emailSender.Send(message));
    }

}



