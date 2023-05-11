using System.Net;
using SendGrid;
using UsingSendGridApi;
using UsingSendGridApi.Utils;

namespace UsingSendGridUnitTests;

public class SendGridWithOfficialLibraryTests : IClassFixture<SendGridUnitTestFixture>
{
    private const string ToEmail = "recipient@test.com";
    private const string FromEmail = "sender@test.com";

    private readonly HttpClient _httpClient;

    public SendGridWithOfficialLibraryTests(SendGridUnitTestFixture fixture) =>
        _httpClient = fixture.MessageHandler.ToHttpClient();

    [Fact]
    public async Task GivenAuthorizedClient_WhenSendingMail_ThenResultIsAccepted()
    {
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) =
            await sendGrid.SendMailUsingMailHelper(ToEmail, FromEmail, "Test Email",
                                                   "This is the content", null).ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenUnauthorizedClient_WhenSendingMail_ThenResultIsUnauthorized()
    {
        var sendGrid = new SendGridClient(_httpClient, "UnauthorizedApiKey");
        var (success, statusCode) =
            await sendGrid.SendMailUsingMailHelper(ToEmail, FromEmail, "Test Email",
                                                   "This is the content", null).ConfigureAwait(false);

        Assert.False(success);
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }

    [Fact]
    public async Task GivenFileToEmail_WhenAttaching_ResultIsAccepted()
    {
        await using var pdfFile =
            await Utilities.CreateTemporaryFileWithSpecifiedSize(1024, ".pdf").ConfigureAwait(false);
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) = await sendGrid
                                         .SendMailWithAttachment(ToEmail, FromEmail, "Test Email", pdfFile.FileName,
                                                                 "application/pdf", null, false, "This is the content",
                                                                 null).ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenScheduleForEmail_WhenConfiguringSchedule_ResultIsAccepted()
    {
        var sendGrid = new SendGridClient(_httpClient, SendGridUnitTestFixture.SendGridAuthorizationKey);
        var (success, statusCode) = await sendGrid
                                         .SendScheduledEmail(ToEmail, FromEmail, null, null, "Scheduled Email",
                                                             DateTime.Now.AddDays(1), "This is the content", null)
                                         .ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }
}