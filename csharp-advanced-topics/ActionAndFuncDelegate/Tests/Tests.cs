using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DelegateExample.Models;

namespace DelegateExample.Tests
{
    [TestClass()]
    public class Tests
    {

		public static List<Employee> Employees = new()
		{
			new Employee() { Name = "John", Age = 20 },
			new Employee() { Name = "Lora", Age = 25 }
		};

		[TestMethod]
		public void WhenActionDelegate_DelegateExecutesPrintName()
		{
            try
            {
				Action<Employee> NamePrinter = Program.PrintName;

				NamePrinter(Employees.First());

				Assert.IsTrue(true);
			}
            catch (Exception)
            {

                Assert.Fail();
            }
			
		}

		[TestMethod]
		public void WhenFuncDelegate_DelegateExecutesGetName()
		{
			Func<Employee, string> NameSelector = Program.GetName;

			var names = Employees.Select(NameSelector);

			Assert.IsNotNull(names);
		}
	}
}