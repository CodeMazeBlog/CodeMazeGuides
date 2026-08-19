using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace EmployeesApp.AutomatedUITests
{
	public class AutomatedUITests : IDisposable
	{
		private readonly IWebDriver _driver;
		private readonly EmployeePage _page;

		public AutomatedUITests()
		{
			_driver = new ChromeDriver();
			_page = new EmployeePage(_driver);
			_page.Navigate();
		}

		[Fact]
		public void Create_WhenExecuted_ReturnsCreateView()
		{
			Assert.Equal("Create - EmployeesApp", _page.Title);
			Assert.Contains("Please provide a new employee data", _page.Source);
		}

		[Fact]
		public void Create_WrongModelData_ReturnsErrorMessage()
		{
			_page.PopulateName("New Name");
			_page.PopulateAge("34");
			_page.ClickCreate();

			Assert.Equal("Account number is required", _page.AccountNumberErrorMessage);
		}

		[Fact]
		public void Create_WhenSuccessfullyExecuted_ReturnsIndexViewWithNewEmployee()
		{
			_page.PopulateName("New Name");
			_page.PopulateAge("34");
			_page.PopulateAccountNumber("123-9384613085-58");
			_page.ClickCreate();

			Assert.Equal("Index - EmployeesApp", _page.Title);
			Assert.Contains("New Name", _page.Source);
			Assert.Contains("34", _page.Source);
			Assert.Contains("123-9384613085-58", _page.Source);
		}

		public void Dispose()
		{
			_driver.Quit();
			_driver.Dispose();
		}
	}
}