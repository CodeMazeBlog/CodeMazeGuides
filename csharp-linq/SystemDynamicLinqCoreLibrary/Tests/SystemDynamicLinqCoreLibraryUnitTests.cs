using SystemDynamicLinqCoreLibrary;

namespace Tests
{
    public class SystemDynamicLinqCoreLibraryUnitTests
    {
        private TestData _employeeTestData;

        [SetUp]
        public void SetUp()
        {
            _employeeTestData = new TestData();
        }

        [TestCase("IT", 2)]
        [TestCase("Human Resource", 2)]
        [TestCase("Infrastructure", 1)]
        [TestCase("Hospitality", 1)]
        [TestCase("Finance", 2)]
        public void WhenDepartmentIsPassedUsingTypedLinq_ThenReturnDepartmentEmployees(string input, int expected)
        {
            var actual = _employeeTestData.FilterEmployeesByDepartmentUsingTypedLinq(input);

            Assert.AreEqual(expected, actual.Count);
            Assert.NotNull(actual);
        }

        [TestCase("IT", 2)]
        [TestCase("Human Resource", 2)]
        [TestCase("Infrastructure", 1)]
        [TestCase("Hospitality", 1)]
        [TestCase("Finance", 2)]
        public void WhenDepartmentIsPassed_ThenReturnDepartmentEmployees(string input, int expected)
        {
            var actual = _employeeTestData.FilterEmployeesByDepartment(input);

            Assert.AreEqual(expected, actual.Count);
            Assert.NotNull(actual);
        }

        [TestCase(2)]
        public void WhenEscapeSequenceIsUsed_ThenReturnDepartmentEmployees(int expected)
        {
            var actual = _employeeTestData.FilterEmployeesUsingEscapeSequence();

            Assert.AreEqual(expected, actual.Count);
            Assert.NotNull(actual);
        }

        [TestCase(2)]
        public void WhenLambdaOperatorIsUsed_ThenReturnDepartmentEmployees(int expected)
        {
            var actual = _employeeTestData.FilterEmployeesUsingLambdaOperator();

            Assert.AreEqual(expected, actual.Count);
            Assert.NotNull(actual);
        }


        [TestCase(8)]
        public void WhenNameAndDepartmentAreSelected_ThenReturnAllEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SelectEmployees();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenNameAndDepartmentAreSelectedUsingTypedLinq_ThenReturnAllEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SelectEmployeesUsingTypedLinq();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenEmployeesAreSorted_ThenReturnSortedEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SortEmployees();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenEmployeesAreSortedUsingTypedLinq_ThenReturnSortedEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SortEmployeesUsingTypedLinq();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenMultipleSortPropertiesArePassed_ThenReturnSortedEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SortEmployeesByMultipleProperties();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenMultipleSortPropertiesArePassedTypedLinq_ThenReturnSortedEmployees(int expectedCount)
        {
            var actualEmployees = _employeeTestData.SortEmployeesByMultiplePropertiesUsingTypedLinq();

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(expectedCount, actualEmployees.Count);
        }

        [TestCase("Test Company", 1)]
        public void WhenEmployerNameIsSpecified_ThenReturnEmployeesForEmployer(string employer, int employeeCount)
        {
            var actualEmployees = _employeeTestData.GetEmployeesByEmployer(employer);

            Assert.NotNull(actualEmployees);
            Assert.AreEqual(employeeCount, actualEmployees.Count);
        }

        [TestCase(8)]
        public void WhenEmployerNameIsUnspecified_ThenSetEmployerNameToUnspecified(int employeeCount)
        {
            var actual = _employeeTestData.GetEmployeesWhereEmployerIsNull();

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
            var filteredEmployees = _employeeTestData.CreateDynamicLambdaExpressions(department, age);

            Assert.AreEqual(expectedCount, filteredEmployees.Count);
        }
    }
}