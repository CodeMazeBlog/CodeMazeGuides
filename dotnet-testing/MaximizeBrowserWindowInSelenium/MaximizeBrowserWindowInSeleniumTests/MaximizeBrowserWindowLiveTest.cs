using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace MaximizeBrowserWindowInSeleniumTests;

public class MaximizeBrowserWindowLiveTest : IDisposable
{
    private IWebDriver ?driver;

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();
    }

    [Fact]
    public void GivenTestInChrome_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        Dispose();
    }

    [Fact]
    public void GivenTestInChromeWOptions_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        ChromeOptions options = new ChromeOptions();

        options.AddArguments("--start-maximized");

        driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        Dispose();
    }

    [Fact]
    public void GivenTestInFirefox_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

        driver = new FirefoxDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        Dispose();
    }

    [Fact]
    public void GivenTestInMSEdge_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        EdgeDriverService service = EdgeDriverService.CreateDefaultService();

        driver = new EdgeDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        Dispose();
    }

    [Fact]
    public void GivenTestInSafari_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        SafariDriverService service = SafariDriverService.CreateDefaultService();

        driver = new SafariDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        Dispose();
    }
}
