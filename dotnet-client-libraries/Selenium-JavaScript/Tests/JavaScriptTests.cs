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

        // Find the hidden element and ensure it's initially not displayed
        var hiddenElement = _driver.FindElement(By.Id("hidden-element"));
        hiddenElement.GetCssValue("display").Should().Be("none");

        // Execute JavaScript to make the hidden element visible
        jsExecutor.ExecuteScript("document.getElementById('hidden-element').style.display='block';");

        // Wait for the JavaScript execution to take effect (optional, depends on context)
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        wait.Until(ExpectedConditions.ElementIsVisible(By.Id("hidden-element")));

        // Re-check the display property of the hidden element
        hiddenElement.GetCssValue("display").Should().Be("block");
    }

    [Fact]
    public void WhenFoundButton_ThenClickLiveTest()
    {
        _driver.Navigate().GoToUrl(_webUrl + "/Home/Index");

        var button = _driver.FindElement(By.Id("testButton"));

        var js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("arguments[0].click();", button);
    }

    [Fact]
    public void WhenDelayedLoadingContent_ThenWaitUntilDocumentFullyLoadedLiveTest()
    {
        _driver.Navigate().GoToUrl(_webUrl + "/Home/Sync");

        var js = (IJavaScriptExecutor)_driver;
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => (bool)js.ExecuteScript("return document.readyState === 'complete';"));

        // Wait for the dynamic content to be loaded
        wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.Id("dynamicContent"), "Content Loaded"));

        // Now check if the dynamic content is loaded
        var dynamicContent = _driver.FindElement(By.Id("dynamicContent"));
        dynamicContent.Text.Should().Be("Content Loaded");
    }

    public void Dispose()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}
