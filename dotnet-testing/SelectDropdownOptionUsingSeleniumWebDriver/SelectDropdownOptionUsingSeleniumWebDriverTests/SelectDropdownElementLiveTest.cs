using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SelectDropdownOptionUsingSeleniumWebDriverTests;

public class SelectDropdownElementLiveTest
{
    [Fact]
    public void GivenTestInChrome_WhenDropdownElementIsSelectedByText_ThenOptionValueIsReturned()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var dropdown = driver.FindElement(By.Id("programming-language"));

        var selectElement = new SelectElement(dropdown);

        selectElement.SelectByText("JavaScript");

        Assert.Equal("javascript", selectElement.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void GivenTestInChrome_WhenDropdownElementIsSelectedByIndex_ThenOptionValueIsReturned()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var dropdown = driver.FindElement(By.Id("programming-language"));

        var selectElement = new SelectElement(dropdown);

        selectElement.SelectByIndex(0);

        Assert.Equal("csharp", selectElement.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void GivenTestInChrome_WhenDropdownElementIsSelectedByValue_ThenOptionValueIsReturned()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var dropdown = driver.FindElement(By.Id("programming-language"));

        var selectElement = new SelectElement(dropdown);

        selectElement.SelectByValue("php");

        Assert.Equal("php", selectElement.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void GivenTestInChrome_WhenDropdownElementIsSelectedByXPath_ThenOptionValueIsReturned()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var option = driver.FindElement(
            By.XPath("//select[@id='programming-language']/option[@value='typescript']"));

        string selectedOptionValue = option.GetAttribute("value");

        Assert.Equal("typescript", selectedOptionValue);

        driver.Quit();
    }

    [Fact]
    public void GivenTestInFirefox_WhenDropdownElementIsSelectedByText_ThenOptionValueIsReturned()
    {
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

        IWebDriver driver = new FirefoxDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var dropdown = driver.FindElement(By.Id("programming-language"));

        var selectElement = new SelectElement(dropdown);

        selectElement.SelectByText("Java");

        Assert.Equal("java", selectElement.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void GivenTestInEdge_WhenDropdownElementIsSelectedByText_ThenOptionValueIsReturned()
    {
        EdgeDriverService service = EdgeDriverService.CreateDefaultService();

        IWebDriver driver = new EdgeDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7006/");

        var dropdown = driver.FindElement(By.Id("programming-language"));

        var selectElement = new SelectElement(dropdown);

        selectElement.SelectByText("Rust");

        Assert.Equal("rust", selectElement.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }
}
