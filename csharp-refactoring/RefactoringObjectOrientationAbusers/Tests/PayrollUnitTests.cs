using RefactoringObjectOrientationAbusers.RefusedBequest.ReplaceInheritanceWithDelegation.Correct;

namespace Tests
{
    [TestClass]
    public class PayrollUnitTests
    {
        [TestMethod]
        public void WhenCalculatingPay_ThenCorrectValueIsReturn()
        {
            // Arrange
            decimal hourlyRate = 10.00M;
            int hoursWorked = 40;
            Paycheck paycheck = new Paycheck(hourlyRate, hoursWorked);

            // Act
            decimal pay = paycheck.CalculatePay();

            // Assert
            Assert.AreEqual(400.00M, pay);
        }

        [TestMethod]
        public void WhenGetOvertimeRate_ThenCorrectValueIsReturn()
        {
            // Arrange
            decimal hourlyRate = 10.00M;
            int hoursWorked = 50;
            Paycheck paycheck = new Paycheck(hourlyRate, hoursWorked);

            // Act
            decimal overtimeRate = paycheck.GetOvertimeRate();

            // Assert
            Assert.AreEqual(15.00M, overtimeRate);
        }

        [TestMethod]
        public void WhenCalculatingPayForEmployee_ThenCorrectValueIsReturn()
        {
            // Arrange
            decimal hourlyRate = 10.00M;
            int hoursWorked = 40;
            Paycheck paycheck = new Paycheck(hourlyRate, hoursWorked);
            Employee employee = new Employee(paycheck);

            // Act
            decimal pay = employee.CalculatePay();

            // Assert
            Assert.AreEqual(400.00M, pay);
        }
    }
}
