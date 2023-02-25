using AccessModifiersInCsharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void GivenPublicMemberThenAllAccessibleFromOutside()
        {
            var calculator = new Calculator();
            calculator.Value = 100;

            var expected = 101;
            var actual = calculator.IncrementValue(calculator.Value);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenClassWithPrivateMemberThenOnlyPublicAccessibleFromOutside()
        {
            var bankAccount = new BankAccount();
            bankAccount.Deposit(1000);
            bankAccount.Withdraw(600);

            var expected = 400;
            var actual = bankAccount.GetBalance();

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void GivenClassWithProtectedMemberThenOnlyPublicAccessibleFromOutside()
        {
            var shape = new TestShape(20, 60);

            var expected = 1200;
            var actual = shape.GetArea();

            Assert.Equal(expected, actual);
        }
    }
}