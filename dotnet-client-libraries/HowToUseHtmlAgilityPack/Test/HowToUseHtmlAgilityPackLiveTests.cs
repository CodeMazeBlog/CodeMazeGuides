using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Test
{
    public class HowToUseHtmlAgilityPackLiveTests
    {
        [Fact]
        public void WhenGettingHtmlUsingSelenium_ThenCanAccessDynamicContent()
        {
            // arrange
            var options = new ChromeOptions();
            options.AddArguments("headless");

            using (var driver = new ChromeDriver(options))
            {
                // act
                driver.Navigate().GoToUrl("https://code-maze.com/");

                var doc = new HtmlDocument();
                doc.LoadHtml(driver.PageSource);

                var node = doc.DocumentNode.SelectSingleNode("//head/title");

                // assert
                Assert.Equal("Code Maze - C#, .NET and Web Development Tutorials", node.InnerHtml);
            }
        }
    }
}
