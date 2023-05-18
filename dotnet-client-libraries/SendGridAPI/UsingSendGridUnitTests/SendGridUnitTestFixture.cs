using System.Net;
using DisposableFileSystem;
using NJsonSchema;
using RichardSzalay.MockHttp;
using SendGrid.Helpers.Mail;

namespace UsingSendGridUnitTests;

public sealed class SendGridUnitTestFixture : IDisposable
{
    public const string SendGridAuthorizationKey = "SK_b0d57701-59c9-497e-9f9d-80562e62898d";
    private readonly DisposableDirectory _directory;

    public HttpClient AuthorizedClient { get; }

    private JsonSchema Schema { get; }
    public MockHttpMessageHandler MessageHandler { get; } = new();

    public SendGridUnitTestFixture()
    {
        Schema = JsonSchema.FromType<SendGridMessage>();
        AuthorizedClient = GetAuthorizedClient();

        _directory = DisposableDirectory.Create();

        ConfigureMessageHandler();
    }

    private HttpClient GetAuthorizedClient()
    {
        var client = MessageHandler.ToHttpClient();
        client.BaseAddress = new Uri("https://api.sendgrid.com/");
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {SendGridAuthorizationKey}");

        return client;
    }

    private void ConfigureMessageHandler()
    {
        MessageHandler.Fallback.Throw(new InvalidOperationException("No matching mock handler."));

        MessageHandler.When("https://api.sendgrid.com/v3/mail/send").Respond(async message =>
        {
            ArgumentNullException.ThrowIfNull(message, nameof(message));
            var auth = message.Headers.Authorization;

            if (auth is null || !auth.Scheme.Equals("Bearer", StringComparison.Ordinal) ||
                !string.Equals(auth.Parameter, SendGridAuthorizationKey, StringComparison.Ordinal))
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            if (message.Content is null) return new HttpResponseMessage(HttpStatusCode.BadRequest);

            var content = await message.Content.ReadAsStringAsync();

            return Schema.Validate(content).Count > 0
                ? new HttpResponseMessage(HttpStatusCode.BadRequest)
                : new HttpResponseMessage(HttpStatusCode.Accepted) {Content = message.Content};
        });
    }

    public string GetTempFileName() => _directory.RandomFileName();

    public void Dispose()
    {
        MessageHandler.Dispose();
        AuthorizedClient.Dispose();
        _directory.Dispose();
    }
}