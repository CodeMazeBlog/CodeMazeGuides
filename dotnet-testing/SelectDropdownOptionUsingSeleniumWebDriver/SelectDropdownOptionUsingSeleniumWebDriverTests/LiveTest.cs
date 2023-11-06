using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace SelectDropdownOptionUsingSeleniumWebDriverTests;

public class LiveTest
{
    [Fact]
    public void SelectElementObjectByTextChromeTest()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        SelectElement select = new SelectElement(dropdown);

        select.SelectByText("JavaScript");

        Assert.Equal("javascript", select.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByIndexChromeTest()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        SelectElement select = new SelectElement(dropdown);

        select.SelectByIndex(0);

        Assert.Equal("csharp", select.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByValueChromeTest()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        SelectElement select = new SelectElement(dropdown);

        select.SelectByValue("php");

        Assert.Equal("php", select.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void SelectElementByXpathChromeTest()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement option = driver.FindElement(By.XPath("//select[@id='programming-language']/option[@value='typescript']"));

        string selectedOptionValue = option.GetAttribute("value");

        Assert.Equal("typescript", selectedOptionValue);

        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByTextFirefoxTest()
    {
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

        IWebDriver driver = new FirefoxDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        SelectElement select = new SelectElement(dropdown);

        select.SelectByText("Java");

        Assert.Equal("java", select.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByTextMSEdgeTest()
    {
        EdgeDriverService service = EdgeDriverService.CreateDefaultService();

        IWebDriver driver = new EdgeDriver(service);

        driver.Navigate().GoToUrl("https://localhost:7006/");

        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        SelectElement select = new SelectElement(dropdown);

        select.SelectByText("Rust");

        Assert.Equal("rust", select.SelectedOption.GetAttribute("value"));

        driver.Quit();
    }
}
