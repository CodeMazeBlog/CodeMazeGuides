namespace ActionUsageExample
{
    public class GithubHttpClient : IGithubHttpClient
    {
        public async void FetchRepositoryList(string githubId, int fetchCount, Action<List<string>> OnReceivedRepos)
        {

            //
            // For simplicity, simulating API call instead of actual API call
            // (in actual app, Flurl.Http or native HttpClient will be used)
            //
            var twoSeconds = 2000;
            await Task.Delay(twoSeconds);

            var repoList = new List<string>();
            for (int i = 0; i < fetchCount; i++)
            {
                repoList.Add(@"https://github.com/CodeMazeBlog/blazor-series");
            }

            //
            // Invoke callback
            //
            OnReceivedRepos(repoList);
        }
    }
}
