namespace ActionUsageExample
{
    public interface IGithubHttpClient
    {
        public void FetchRepositoryList(string githubId, int fetchCount, Action<List<string>> OnReceivedRepos);
    }
}
