using AutoFixture.Xunit2;
using System.Collections.Generic;
using FuncUsageExample;
using Xunit;
using System.Linq;

namespace Tests
{
    public class Tests : IClassFixture<GithubHttpClientTestFixure>
    {
        private readonly GithubHttpClientTestFixure _githubClientFixure;

        public Tests(GithubHttpClientTestFixure githubClientFixure)
        {
            _githubClientFixure = githubClientFixure;
        }

        [Theory]
        [InlineAutoData("CodeMazeBlog", 5)]
        [InlineAutoData("hovermind", 2)]
        [InlineAutoData("octocat", 1)]
        public void WhenCalledFetchRepositoryList_ShouldReturnList(string githubId, int fetchCount)
        {
            _githubClientFixure.Sut.FetchRepositoryList(githubId, fetchCount, (repoList) =>
            {
                var expectedResult = fetchCount;

                var actualResult = repoList.Count;

                Assert.Equal(expectedResult, actualResult);
            });
        }

        [Theory]
        [InlineAutoData(1, 5, 2)]
        [InlineAutoData(7, 7, 0)]
        [InlineAutoData(8, 15, 4)]
        public void WhenCalledFilterOnList_ShouldSelectItemsBasedOnGivenPredicate(int rangeStart, int rangeEnd, int expectedResult)
        {
            var numberList = new List<int>();
            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                numberList.Add(i);
            }

            var filtered = numberList.Filter(number => number % 2 == 0);

            var actualResult = Enumerable.Count(filtered);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}