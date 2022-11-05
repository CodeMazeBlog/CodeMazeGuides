using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using SystemDynamicLinqCoreLibrary;

namespace Tests
{
    public class SystemDynamicLinqCoreLibraryUnitTest
    {
        private Employee _employee;

        [SetUp]
        public void SetUp()
        {
            _employee = new Employee();
        }

        [TestCase("IT", 2)]
        [TestCase("Human Resource", 2)]
        [TestCase("Infrastructure", 1)]
        [TestCase("Hospitality", 1)]
        [TestCase("Finance", 2)]
        public void WhenDepartmentIsPassed_ThenReturnDepartmentEmployees(string input, int expected)
        {
            var employees = _employee.GetEmployees();
            var actualResult = employees.Where("Department == @0", input).ToList();

            Assert.AreEqual(expected, actualResult.Count);
            Assert.NotNull(actualResult);
        }

        [TestCase(8)]
        public void WhenNameAndDepartmentSelected_ThenReturnAllEmployees(int expectedCount)
        {
            var employees = _employee.GetEmployees();
            var actualEmployees = employees.Select("new {Name, Department}").ToDynamicList();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase("Block 10", 1)]
        public void WhenEmployerNameIsSpecified_ThenReturnEmployeesForEmployer(string employer, int employeeCount)
        {
            var employees = _employee.GetEmployees();

            var actualEmployees = employees.Where("np(Employer.Name) == @0", employer).ToList();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(employeeCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenEmployerNameIsUnspecified_ThenSetEmployerNameToUnspecified(int employeeCount)
        {
            var employees = _employee.GetEmployees();
            var actual = employees.Select("np(Employer.Name, \"Not Specified\")").ToDynamicList();

            Assert.NotNull(actual);
            Assert.AreEqual(employeeCount, actual.Count);
        }

        [TestCase("IT", 18, 2)]
        [TestCase("Human Resource", 18, 2)]
        [TestCase("Infrastructure", 18, 1)]
        [TestCase("Hospitality", 18, 1)]
        [TestCase("Finance", 18, 2)]
        public void WhenDepartmentAndAgeArePassed_ReturnEmployeesInDepartment(string department, int age,
            int expectedCount)
        {
            var employees = _employee.GetEmployees();

            Expression<Func<Employee, bool>> employeeDepartment = DynamicExpressionParser
                .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Department = @0", department);

            Expression<Func<Employee, bool>> employeeAge = DynamicExpressionParser
                .ParseLambda<Employee, bool>(new ParsingConfig(), true, "Age >= @0", age);

            var filtetedEmployees = employees.Where("@0(it) and @1(it)", employeeDepartment, employeeAge).ToList();

            Assert.AreEqual(expectedCount, filtetedEmployees.Count);
        }
    }
}