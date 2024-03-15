using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Tests;
public class JavaScriptTests : IClassFixture<WebFactory>, IDisposable
{
    private readonly IWebDriver _driver;

    private readonly string _webUrl = "https://localhost:5055";

    public JavaScriptTests(WebFactory factory)
    {
        factory.HostUrl = _webUrl;
        factory.CreateDefaultClient();

        _driver = new ChromeDriver();
    }

    [Fact]
    public void WhenHiddenElement_ThenMakeVisibleLiveTest()
    {
        _driver.Navigate().GoToUrl(_webUrl + "/Home/Index");

        var jsExecutor = (IJavaScriptExecutor)_driver;

        var hiddenElement = _driver.FindElement(By.Id("hidden-element"));
        hiddenElement.GetCssValue("display").Should().Be("none");

        jsExecutor.ExecuteScript("document.getElementById('hidden-element').style.display='block';");

        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("hidden-element")));

        hiddenElement.GetCssValue("display").Should().Be("block");
    }

    [Fact]
    public void WhenFoundButton_ThenClickLiveTest()
    {
        _driver.Navigate().GoToUrl(_webUrl + "/Home/Index");

        var button = _driver.FindElement(By.Id("testButton"));

        var jsExecutor = (IJavaScriptExecutor)_driver;
        jsExecutor.ExecuteScript("arguments[0].click();", button);
    }

    [Fact]
    public void WhenDelayedLoadingContent_ThenWaitUntilDocumentFullyLoadedLiveTest()
    {
        _driver.Navigate().GoToUrl(_webUrl + "/Home/Sync");

        var jsExecutor = (IJavaScriptExecutor)_driver;
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => (bool)jsExecutor.ExecuteScript("return document.readyState === 'complete';"));

        wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("dynamicContent"), "Content Loaded"));

        var dynamicContent = _driver.FindElement(By.Id("dynamicContent"));
        dynamicContent.Text.Should().Be("Content Loaded");
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
