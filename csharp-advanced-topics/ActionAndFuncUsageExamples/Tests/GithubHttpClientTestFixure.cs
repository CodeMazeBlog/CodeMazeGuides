using ActionUsageExample;
using System;

namespace Tests
{
    public class GithubHttpClientTestFixure : IDisposable
    {
        public IGithubHttpClient Sut { get; private set; }

        public GithubHttpClientTestFixure()
        {
            Sut = new GithubHttpClient();

            // In actual application, dependencies will be mocked
            // var mocked = new Mock<ILogger<GithubHttpClient>>();
            // Sut = new GithubHttpClient(mocked.Object);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
