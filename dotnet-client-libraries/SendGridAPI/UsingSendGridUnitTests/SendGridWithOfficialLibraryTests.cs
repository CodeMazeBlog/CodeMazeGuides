using System.Net;
using SendGrid;
using SendGrid.Helpers.Mail;
using UsingSendGridApi;
using UsingSendGridApi.Utils;

namespace UsingSendGridUnitTests;

public sealed class SendGridWithOfficialLibraryTests : IClassFixture<SendGridUnitTestFixture>
{
    private const string ToEmail = "recipient@test.com";
    private const string FromEmail = "sender@test.com";
    private readonly SendGridUnitTestFixture _fixture;

    private readonly HttpClient _httpClient;

    public SendGridWithOfficialLibraryTests(SendGridUnitTestFixture fixture)
    {
        _fixture = fixture;
        _httpClient = _fixture.MessageHandler.ToHttpClient();
    }

    [Fact]
    public async Task GivenAuthorizedClient_WhenSendingMail_ThenResultIsAccepted()
    {
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) =
            await sendGrid.SendMailUsingMailHelper(new EmailAddress(ToEmail), new EmailAddress(FromEmail), "Test Email",
                "This is the content", null).ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenUnauthorizedClient_WhenSendingMail_ThenResultIsUnauthorized()
    {
        var sendGrid = new SendGridClient(_httpClient, "UnauthorizedApiKey");
        var (success, statusCode) =
            await sendGrid.SendMailUsingMailHelper(new EmailAddress(ToEmail), new EmailAddress(FromEmail), "Test Email",
                "This is the content", null).ConfigureAwait(false);

        Assert.False(success);
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }

    [Fact]
    public async Task GivenFileToEmail_WhenAttaching_ResultIsAccepted()
    {
        var pdfFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(pdfFile, 1024).ConfigureAwait(false);
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) = await sendGrid
            .SendMailWithAttachment(new EmailAddress(ToEmail), new EmailAddress(FromEmail),
                "Test Email", pdfFile, "application/pdf", null, false, "This is the content", null)
            .ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenScheduleForEmail_WhenConfiguringSchedule_ResultIsAccepted()
    {
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) = await sendGrid
            .SendScheduledEmail(new EmailAddress(ToEmail), new EmailAddress(FromEmail),
                null, null, "Scheduled Email",
                DateTime.Now.AddDays(1), "This is the content", null)
            .ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenTooLargeFileToEmail_WhenAttaching_ResultArgumentException()
    {
        var largeFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(largeFile, (int) Utilities.MaxAttachmentSize + 124);
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await sendGrid
                  .SendMailWithAttachment(new EmailAddress(ToEmail),
                      new EmailAddress(FromEmail), "Email with Attachment", largeFile,
                      "application/pdf", null, false, "This is the email content", null)
                  .ConfigureAwait(false)
        );
    }

    [Fact]
    public async Task GivenNonExistentFileToEmail_WhenAttaching_ResultFileNotFoundException()
    {
        var tempFile = Path.GetTempFileName();
        File.Delete(tempFile);
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);

        await Assert.ThrowsAsync<FileNotFoundException>(async () =>
            await sendGrid
                  .SendMailWithAttachment(new EmailAddress(ToEmail), new EmailAddress(FromEmail),
                      "Email with Attachment", tempFile, "application/pdf", null, false,
                      "This is the email content", null)
                  .ConfigureAwait(false)
        );
    }
}