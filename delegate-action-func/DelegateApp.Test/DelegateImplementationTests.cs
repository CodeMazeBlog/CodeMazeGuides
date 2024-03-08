
namespace DelegateApp.Test
{
    public class DelegateImplementationTests
    {
        private readonly DelegateImplementation _implementation;

        public DelegateImplementationTests()
        {
            _implementation = new DelegateImplementation();
        }

        [Fact]
        public void Func_Test()
        {
            var result = _implementation.GetEmployee(1, "Name", EmployeeType.FullTime);
            Assert.IsType<Employee>(result);
            Assert.Equal(1, result.Id); 
            Assert.Equal("Name", result.Name);
            Assert.Equal(EmployeeType.FullTime, result.EmployeeType);
        }

        [Fact]
        public void Action_Test()
        {   
            var emp = _implementation.GetEmployee(1, "Name", EmployeeType.FullTime);
            var expectedOutput = $"{emp.Name} is a {emp.EmployeeType} employee.";

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                _implementation.Print(emp);
                Assert.Equal(expectedOutput, writer.ToString().Trim());
            }
           
        }
    }
}