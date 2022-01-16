
using ActionUsageExample;

IGithubHttpClient githubClient = new GithubHttpClient();

Console.WriteLine("Calling Github API \n");

githubClient
    .FetchRepositoryList(
        githubId: "CodeMazeBlog",
        fetchCount: 3,
        OnReceivedRepos: (repoList) =>
        {
            // Update UI when data is received
            Console.WriteLine($"Received repository list \nRepositoryCount : {repoList.Count}");
        });

Console.WriteLine("When data is being fecthed, perforing other tasks in UI i.e. updating progress bar.\n");

var _ = Console.ReadKey();
