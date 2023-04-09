using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class EmployeeUnitTest
    {
        [DataTestMethod]
        [DataRow(0, typeof(Administrator))]
        [DataRow(1, typeof(ContentWriter))]
        [DataRow(2, typeof(Developer))]
        public void GivenEmployeeTypeCode_WhenCreatingNewEmployee_ThenCorrectObjectIsCreated(int employeeTypeCode, Type expectedType)
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";

            // Act
            var employee = Employee.Create(firstName, lastName, employeeTypeCode);

            // Assert
            Assert.AreEqual(expectedType, employee.GetType());
        }

        [DataTestMethod]
        [DataRow(0, 0.1)]
        [DataRow(1, 0.05)]
        [DataRow(2, 0.15)]
        public void GivenBonusRateBasedOnEmployeeType_WhenGettingMonthlyBonus_ThenCorrectValueIsReturned(int employeeTypeCode, double expectedBonus)
        {
            // Arrange
            var firstName = "John";
            var lastName = "Doe";
            var salary = 5000;
            var employee = Employee.Create(firstName, lastName, employeeTypeCode);

            // Act
            var bonus = employee.GetMonthlyBonus(salary);

            // Assert
            Assert.AreEqual(salary * expectedBonus, bonus);
        }
    }
}