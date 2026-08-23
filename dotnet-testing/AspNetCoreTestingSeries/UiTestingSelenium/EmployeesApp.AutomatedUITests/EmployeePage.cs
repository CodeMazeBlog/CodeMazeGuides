using OpenQA.Selenium;

namespace EmployeesApp.AutomatedUITests
{
	public class EmployeePage
	{
		private readonly IWebDriver _driver;
		private const string URI = "https://localhost:5001/Employees/Create";

		private IWebElement NameElement => _driver.FindElement(By.Id("Name"));
		private IWebElement AgeElement => _driver.FindElement(By.Id("Age"));
		private IWebElement AccountNumberElement => _driver.FindElement(By.Id("AccountNumber"));
		private IWebElement CreateElement => _driver.FindElement(By.Id("Create"));

		public string Title => _driver.Title;
		public string Source => _driver.PageSource;
		public string AccountNumberErrorMessage => _driver.FindElement(By.Id("AccountNumber-error")).Text;

		public EmployeePage(IWebDriver driver) => _driver = driver;

		public void Navigate() => _driver.Navigate()
				.GoToUrl(URI);
		
		public void PopulateName(string name) => NameElement.SendKeys(name);
		public void PopulateAge(string age) => AgeElement.SendKeys(age);
		public void PopulateAccountNumber(string accountNumber) => AccountNumberElement.SendKeys(accountNumber);
		public void ClickCreate() => CreateElement.Click();
	}
}
