using EmployeesApp.Contracts;
using EmployeesApp.Controllers;
using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EmployeesApp.Tests.Controller
{
	public class EmployeesControllerTests
	{
		private readonly Mock<IEmployeeRepository> _mockRepo;
		private readonly EmployeesController _controller;

		public EmployeesControllerTests()
		{
			_mockRepo = new Mock<IEmployeeRepository>();
			_controller = new EmployeesController(_mockRepo.Object);
		}

		[Fact]
		public void Index_ActionExecutes_ReturnsViewForIndex()
		{
			var result = _controller.Index();
			Assert.IsType<ViewResult>(result);
		}

		[Fact]
		public void Index_ActionExecutes_ReturnsExactNumberOfEmployees()
		{
			_mockRepo.Setup(repo => repo.GetAll())
				.Returns(new List<Employee>() { new Employee(), new Employee() });

			var result = _controller.Index();

			var viewResult = Assert.IsType<ViewResult>(result);
			var employees = Assert.IsType<List<Employee>>(viewResult.Model);
			Assert.Equal(2, employees.Count);
		}

		[Fact] 
		public void Create_ActionExecutes_ReturnsViewForCreate() 
		{ 
			var result = _controller.Create(); 
			
			Assert.IsType<ViewResult>(result); 
		}

		[Fact] 
		public void Create_InvalidModelState_ReturnsView() 
		{ 
			_controller.ModelState.AddModelError("Name", "Name is required"); 
			
			var employee = new Employee { Age = 25, AccountNumber = "255-8547963214-41" }; 
			
			var result = _controller.Create(employee); 
			
			var viewResult = Assert.IsType<ViewResult>(result); 
			var testEmployee = Assert.IsType<Employee>(viewResult.Model); 
			
			Assert.Equal(employee.AccountNumber, testEmployee.AccountNumber); 
			Assert.Equal(employee.Age, testEmployee.Age); 
		}

		[Fact] 
		public void Create_InvalidModelState_CreateEmployeeNeverExecutes() 
		{ 
			_controller.ModelState.AddModelError("Name", "Name is required"); 
			
			var employee = new Employee { Age = 34 }; 
			
			_controller.Create(employee); 
			
			_mockRepo.Verify(x => x.CreateEmployee(It.IsAny<Employee>()), Times.Never); 
		}

		[Fact]
		public void Create_ModelStateValid_CreateEmployeeCalledOnce()
		{
			Employee? emp = null;

			_mockRepo.Setup(r => r.CreateEmployee(It.IsAny<Employee>()))
				.Callback<Employee>(x => emp = x);

			var employee = new Employee
			{
				Name = "Test Employee",
				Age = 32,
				AccountNumber = "123-5435789603-21"
			};

			_controller.Create(employee);
			_mockRepo.Verify(x => x.CreateEmployee(It.IsAny<Employee>()), Times.Once);

			Assert.Equal(emp.Name, employee.Name);
			Assert.Equal(emp.Age, employee.Age);
			Assert.Equal(emp.AccountNumber, employee.AccountNumber);
		}

		[Fact]
		public void Create_ActionExecuted_RedirectsToIndexAction()
		{
			var employee = new Employee
			{
				Name = "Test Employee",
				Age = 45,
				AccountNumber = "123-4356874310-43"
			};

			var result = _controller.Create(employee);

			var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

			Assert.Equal("Index", redirectToActionResult.ActionName);
		}
	}
}
