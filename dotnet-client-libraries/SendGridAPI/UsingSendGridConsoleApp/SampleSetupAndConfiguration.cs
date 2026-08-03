using DisposableFileSystem;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using UsingSendGridApi.Utils;

namespace UsingSendGridConsoleApp;

internal sealed class SampleSetupAndConfigurationHelper : IDisposable, IAsyncDisposable
{
    private const ushort TestingPort = 3000;

    private readonly DisposableDirectory _tempDirectory;
    private readonly IContainer _testContainer;
    private bool _disposedValue;

    public string PdfFile { get; }

    public Uri ContainerUri { get; }

    private SampleSetupAndConfigurationHelper(IContainer testContainer, Uri containerUri,
        DisposableDirectory tempDirectory, string pdfFile)
    {
        _testContainer = testContainer;
        ContainerUri = containerUri;
        _tempDirectory = tempDirectory;
        PdfFile = pdfFile;
    }

    public static async Task<SampleSetupAndConfigurationHelper> Create()
    {
        var testContainer = new ContainerBuilder()
            .WithImage(@"ghashange/sendgrid-mock:1.8.4")
            .WithEnvironment("API_KEY", SampleConstants.ApiKey)
            .WithPortBinding(TestingPort, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(TestingPort))
            .Build();

        await testContainer.StartAsync().ConfigureAwait(false);
        var containerUri =
            new UriBuilder("http", testContainer.Hostname, testContainer.GetMappedPublicPort(TestingPort)).Uri;

        var tempDirectory = DisposableDirectory.Create();
        var pdfFile = Path.Combine(tempDirectory.Path, Path.GetRandomFileName()) + ".pdf";
        await Utilities.FillFileWithRandomDataOfSpecifiedLength(pdfFile, 1024);

        return new SampleSetupAndConfigurationHelper(testContainer, containerUri, tempDirectory, pdfFile);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing) _tempDirectory.Dispose();

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