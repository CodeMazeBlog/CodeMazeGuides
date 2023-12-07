namespace Tests;

public class AutoFacUnitTest
{
    [Fact]
    public void WhenGetEmployeeByIdMethodIsCalled_ThenReturnMatchingEmployee()
    {
        var employeeId = 1;
        var expectedEmployee = new Employee
        {
            Id = employeeId,
            Name = "Jane Doe",
            Title = "Mrs"
        };

        var fakeEmployeeService = A.Fake<IEmployeeService>(options => options.Strict());

        A.CallTo(() => fakeEmployeeService.GetById(employeeId)).Returns(expectedEmployee);

        var employeeService = new EmployeeService(fakeEmployeeService);

        var result = employeeService.GetEmployeeById(1);

        Assert.Equal(employeeId, result.Id);
        Assert.Equal("Jane Doe", result.Name);
    }

    [Fact]
    public void GetAllEmployees_ReturnsEmployeeList()
    {
        var employee1 = new Employee { Id = 1, Name = "John Doe" };
        var employee2 = new Employee { Id = 2, Name = "Jane Doe" };

        var expectedEmployees = new List<Employee> { employee1, employee2 };

        var fakeEmployeeService = A.Fake<IEmployeeService>(options => options.Strict());
        A.CallTo(() => fakeEmployeeService.GetAll()).Returns(expectedEmployees);

        var builder = new ContainerBuilder();
        builder.RegisterInstance(fakeEmployeeService);
        builder.RegisterType<EmployeeService>();
        builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

        var container = builder.Build();
        using var scope = container.BeginLifetimeScope();

        var employeeService = scope.Resolve<EmployeeService>();

        var employees = employeeService.GetAllEmployees();

        Assert.NotNull(employees);
        Assert.Equal(expectedEmployees.Count, employees.Count);
        foreach (var employee in employees)
        {
            Assert.Contains(employee, expectedEmployees);
        }
    }
}