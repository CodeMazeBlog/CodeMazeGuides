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
            var hourlyRate = 10.00M;
            var hoursWorked = 40;
            var paycheck = new Paycheck(hourlyRate, hoursWorked);

            // Act
            var pay = paycheck.CalculatePay();

            // Assert
            Assert.AreEqual(400.00M, pay);
        }

        [TestMethod]
        public void WhenGetOvertimeRate_ThenCorrectValueIsReturn()
        {
            // Arrange
            var hourlyRate = 10.00M;
            var hoursWorked = 50;
            var paycheck = new Paycheck(hourlyRate, hoursWorked);

            // Act
            var overtimeRate = paycheck.GetOvertimeRate();

            // Assert
            Assert.AreEqual(15.00M, overtimeRate);
        }

        [TestMethod]
        public void WhenCalculatingPayForEmployee_ThenCorrectValueIsReturn()
        {
            // Arrange
            var hourlyRate = 10.00M;
            var hoursWorked = 40;
            var paycheck = new Paycheck(hourlyRate, hoursWorked);
            var employee = new Employee(paycheck);

            // Act
            var pay = employee.CalculatePay();

            // Assert
            Assert.AreEqual(400.00M, pay);
        }
    }
}
