using Microsoft.VisualStudio.TestTools.UnitTesting;
using DelegateExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegateExample.Models;

namespace DelegateExample.Tests
{
    [TestClass()]
    public class Tests
    {
		public static string GetName(Employee employee) { return employee.Name; }
		public static string PrintNameValue { get; set; } = string.Empty;
		public static void PrintName(Employee employee) { PrintNameValue = employee.Name; }
		public static List<Employee> Employees = new()
		{
			new Employee() { Name = "John", Age = 20 },
			new Employee() { Name = "Lora", Age = 25 }
		};

		[TestMethod]
		public void WhenActionDelegate_DelegateExecutesPrintName()
		{
			//When
			Action<Employee> NamePrinter = PrintName;
			PrintName(Employees.First());

			//Then
			Assert.AreEqual(Employees.First().Name, PrintNameValue);
		}

		[TestMethod]
		public void WhenFuncDelegate_DelegateExecutesGetName()
		{
			//When
			Func<Employee, string> NameSelector = GetName;
			var names = Employees.Select(NameSelector);

			//Then
			Assert.IsNotNull(names);
		}
	}
}