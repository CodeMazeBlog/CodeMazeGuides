using DisposableFileSystem;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using UsingSendGridApi.Utils;

namespace UsingSendGridConsoleApp;

internal sealed class Helper : IDisposable, IAsyncDisposable
{
    private const ushort TestingPort = 3000;
    public const string ApiKey = "SG.MyFakeSendGridKeyForTesting";
    public const string EmailSubject = "Sending Email with Twilio SendGrid is Fun!";
    public const string EmailWithAttachmentSubject = "Sending Email with Attachment is Also Fun!";
    public const string ToEmail = "john.smith@example.com";
    public const string FromEmail = "Jane.Doe@example.com";
    public const string PlainTextEmailContent = "...and easy to do with C#!";
    public const string HtmlEmailContent = "...and <strong>easy</strong> to do with C#!";

    private readonly DisposableDirectory _tempDirectory = DisposableDirectory.Create();
    private readonly IContainer _testContainer;
    private bool _disposedValue;

    public string PdfFile { get; }

    public Uri? ContainerUri { get; private set; }
    public HttpClient Client { get; }

    public Helper()
    {
        Client = new HttpClient();

        PdfFile = _tempDirectory.RandomFileName();

        _testContainer = new ContainerBuilder()
                         .WithImage(@"ghashange/sendgrid-mock:1.8.4")
                         .WithEnvironment("API_KEY", ApiKey)
                         .WithPortBinding(TestingPort, true)
                         .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(TestingPort))
                         .Build();
    }

    public async Task Initialize()
    {
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(PdfFile, 1024);

        await _testContainer.StartAsync().ConfigureAwait(false);
        ContainerUri = new UriBuilder("http", _testContainer.Hostname, _testContainer.GetMappedPublicPort(TestingPort))
            .Uri;

        Client.BaseAddress = ContainerUri;
        Client.DefaultRequestHeaders.Add("authorization", $"Bearer {ApiKey}");
    }

    public async Task PrintAndCleanUpSentMails()
    {
        Console.WriteLine("Sent mail:");
        var mails = await Client.GetStringAsync("/api/mails").ConfigureAwait(false);
        Console.WriteLine(mails);
        await Client.DeleteAsync("/api/mails").ConfigureAwait(false);
        Console.WriteLine();
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _tempDirectory.Dispose();
                Client.Dispose();
            }

            _disposedValue = true;
        }
    }


    public async ValueTask DisposeAsync()
    {
        Dispose(true);

        await _testContainer.StopAsync().ConfigureAwait(false);
    }


    public void Dispose()
    {
        Dispose(true);
    }
}