using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace MaximizeBrowserWindowInSeleniumTests;

public class MaximizeBrowserWindowLiveTest
{
    [Fact]
    public void GivenTestInChrome_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        driver.Quit();
    }

    [Fact]
    public void GivenTestInChromeWOptions_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        ChromeOptions options = new ChromeOptions();

        options.AddArguments("--start-maximized");

        IWebDriver driver = new ChromeDriver();

        driver = new ChromeDriver(options);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Quit();
    }

    [Fact]
    public void GivenTestInFirefox_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

        IWebDriver driver = new FirefoxDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        driver.Quit();
    }

    [Fact]
    public void GivenTestInMSEdge_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        EdgeDriverService service = EdgeDriverService.CreateDefaultService();

        IWebDriver driver = new EdgeDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        driver.Quit();
    }

    [Fact]
    public void GivenTestInSafari_WhenBrowserNavigatesToURL_ThenBrowserWindowMaximizes()
    {
        SafariDriverService service = SafariDriverService.CreateDefaultService();

        IWebDriver driver = new SafariDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7016/");

        driver.Manage().Window.Maximize();

        driver.Quit();
    }
}
