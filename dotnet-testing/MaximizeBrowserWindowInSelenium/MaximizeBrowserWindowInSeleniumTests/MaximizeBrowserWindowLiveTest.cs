using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace MaximizeBrowserWindowInSeleniumTests;

public class MaximizeBrowserWindowLiveTest : IDisposable
{
    private IWebDriver? _driver; 

    [Fact]
    public void GivenTestInChrome_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        _driver = new ChromeDriver();

        _driver.Navigate().GoToUrl("https://code-maze.com/");

        _driver.Manage().Window.Maximize();
    }

    [Fact]
    public void GivenTestInChromeWOptions_WhenBrowserOpens_ThenBrowserWindowIsMaximized()
    {
        var options = new ChromeOptions();

        options.AddArguments("--start-maximized");

        _driver = new ChromeDriver(options);

        _driver.Navigate().GoToUrl("https://code-maze.com/");
    }

    [Fact]
    public void GivenTestInFirefox_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        var service = FirefoxDriverService.CreateDefaultService();

        _driver = new FirefoxDriver(service);

        _driver.Navigate().GoToUrl("https://code-maze.com/");

        _driver.Manage().Window.Maximize();
    }

    [Fact]
    public void GivenTestInMSEdge_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        var service = EdgeDriverService.CreateDefaultService();

        _driver = new EdgeDriver(service);

        _driver.Navigate().GoToUrl("https://code-maze.com/");

        _driver.Manage().Window.Maximize();
    }

    [Fact]
    public void GivenTestInSafari_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        var service = SafariDriverService.CreateDefaultService();

        _driver = new SafariDriver(service);

        _driver.Navigate().GoToUrl("https://code-maze.com/");

        _driver.Manage().Window.Maximize();
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
