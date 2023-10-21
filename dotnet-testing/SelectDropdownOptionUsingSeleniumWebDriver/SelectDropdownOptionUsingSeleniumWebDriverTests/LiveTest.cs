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
        // Initialize the ChromeDriver WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the dropdown element by its ID
        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        // Use the SelectElement class to interact with the dropdown
        SelectElement select = new SelectElement(dropdown);

        // Select an option by its visible text
        select.SelectByText("JavaScript");

        // Perform assertion to verify the selection
        Assert.Equal("javascript", select.SelectedOption.GetAttribute("value"));

        // Close the browser
        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByIndexChromeTest()
    {
        // Initialize the ChromeDriver WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the dropdown element by its ID
        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        // Use the SelectElement class to interact with the dropdown
        SelectElement select = new SelectElement(dropdown);

        // Select an option by the index
        select.SelectByIndex(0);

        // Perform assertion to verify the selection
        Assert.Equal("csharp", select.SelectedOption.GetAttribute("value"));

        // Close the browser
        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByValueChromeTest()
    {
        // Initialize the ChromeDriver WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the dropdown element by its ID
        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        // Use the SelectElement class to interact with the dropdown
        SelectElement select = new SelectElement(dropdown);

        // Select an option by its value
        select.SelectByValue("php");

        // Perform assertion to verify the selection
        Assert.Equal("php", select.SelectedOption.GetAttribute("value"));

        // Close the browser
        driver.Quit();
    }

    [Fact]
    public void SelectElementByXpathChromeTest()
    {
        // Initialize the ChromeDriver WebDriver
        IWebDriver driver = new ChromeDriver();

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the option via XPath expression
        IWebElement option = driver.FindElement(By.XPath("//select[@id='programming-language']/option[@value='typescript']"));

        // Select an option by getting the value attribute
        string selectedOptionValue = option.GetAttribute("value");

        // Perform assertion to verify the selection
        Assert.Equal("typescript", selectedOptionValue);

        // Close the browser
        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByTextFirefoxTest()
    {
        // Create a FirefoxDriverService instance with default settings
        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();

        // Initialize the FirefoxDriver WebDriver
        IWebDriver driver = new FirefoxDriver(service);

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the dropdown element by its ID
        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        // Use the SelectElement class to interact with the dropdown
        SelectElement select = new SelectElement(dropdown);

        // Select an option by its visible text
        select.SelectByText("Java");

        // Perform assertion to verify the selection
        Assert.Equal("java", select.SelectedOption.GetAttribute("value"));

        // Close the browser
        driver.Quit();
    }

    [Fact]
    public void SelectElementObjectByTextMSEdgeTest()
    {
        // Create an EdgeDriverService instance with default settings
        EdgeDriverService service = EdgeDriverService.CreateDefaultService();

        // Initialize the EdgeDriver WebDriver
        IWebDriver driver = new EdgeDriver(service);

        // Navigate to the home URL of our web app
        driver.Navigate().GoToUrl("https://localhost:7006/");

        // Find the dropdown element by its ID
        IWebElement dropdown = driver.FindElement(By.Id("programming-language"));

        // Use the SelectElement class to interact with the dropdown
        SelectElement select = new SelectElement(dropdown);

        // Select an option by its visible text
        select.SelectByText("Rust");

        // Perform assertion to verify the selection
        Assert.Equal("rust", select.SelectedOption.GetAttribute("value"));

        // Close the browser
        driver.Quit();
    }
}
