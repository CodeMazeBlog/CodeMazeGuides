using System.Net;
using UsingSendGridApi;
using UsingSendGridApi.Utils;

namespace UsingSendGridUnitTests;

public sealed class SendGridWithHttpClientTests : IClassFixture<SendGridUnitTestFixture>
{
    private const string ToEmail = "recipient@test.com";
    private const string FromEmail = "sender@test.com";

    private readonly SendGridUnitTestFixture _fixture;

    public SendGridWithHttpClientTests(SendGridUnitTestFixture fixture) => _fixture = fixture;

    private HttpClient GetTestClient(string? apiKey)
    {
        var client = _fixture.MessageHandler.ToHttpClient();
        client.BaseAddress = new Uri("https://api.sendgrid.com/");
        if (!string.IsNullOrEmpty(apiKey))
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        return client;
    }

    [Fact]
    public async Task GivenAuthorizedClient_WhenSendingMail_ThenResultIsAccepted()
    {
        var (success, statusCode) = await _fixture.AuthorizedClient.SendSimpleEmail(ToEmail, FromEmail, "Test Email",
            "This is the email content").ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenUnauthorizedClient_WhenSendingMail_ThenResultIsUnauthorized()
    {
        using var client = GetTestClient("UnauthorizedApiKey");
        var (success, statusCode) = await client.SendSimpleEmail(ToEmail, FromEmail, "Test Email",
            "This is the email content").ConfigureAwait(false);

        Assert.False(success);
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }

    [Fact]
    public async Task GivenClientWithoutAuthorizationHeader_WhenSendingMail_ThenResultIsUnauthorized()
    {
        using var client = GetTestClient(null);

        Assert.False(client.DefaultRequestHeaders.Contains("Authorization"));

        var (success, statusCode) = await client
            .SendSimpleEmail(ToEmail, FromEmail, "Test Email", "This is the email content")
            .ConfigureAwait(false);

        Assert.False(success);
        Assert.Equal(HttpStatusCode.Unauthorized, statusCode);
    }

    [Fact]
    public async Task GivenFileToEmail_WhenAttaching_ResultIsAccepted()
    {
        var pdfFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(pdfFile, 1024).ConfigureAwait(false);
        var (success, statusCode) = await _fixture.AuthorizedClient
            .SendEmailWithAttachment(ToEmail, FromEmail, "Email with Attachment",
                pdfFile, "application/pdf", "This is the email content")
            .ConfigureAwait(false);

        Assert.True(success);
        Assert.Equal(HttpStatusCode.Accepted, statusCode);
    }

    [Fact]
    public async Task GivenTooLargeFileToEmail_WhenAttaching_ResultArgumentException()
    {
        var largeFile = _fixture.GetTempFileName();
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(largeFile, (int) Utilities.MaxAttachmentSize + 124);

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await _fixture.AuthorizedClient
                .SendEmailWithAttachment(ToEmail,
                    FromEmail, "Email with Attachment", largeFile, "application/pdf",
                    "This is the email content")
                .ConfigureAwait(false)
        );
    }

    [Fact]
    public async Task GivenNonExistentFileToEmail_WhenAttaching_ResultFileNotFoundException()
    {
        var tempFile = Path.GetTempFileName();
        File.Delete(tempFile);

        await Assert.ThrowsAsync<FileNotFoundException>(async () => await _fixture.AuthorizedClient
            .SendEmailWithAttachment(ToEmail, FromEmail, "Email with Attachment",
                tempFile, "application/pdf", "This is the email content")
            .ConfigureAwait(false)
        );
    }
}