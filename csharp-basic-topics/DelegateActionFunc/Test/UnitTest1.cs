namespace Test
{
    public class Tests
    {
        [Test]
        public void TestSumFunc()
        {
            static int SumFunc(int a, int b) => a + b;

            var result = SumFunc(3, 4);

            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void TestActionCalculatorAddition()
        {
            var result = 0;

            Action<int, int> ActionCalculatorAddition = (a, b) =>
            {
                result =a + b;
            };

            ActionCalculatorAddition(9, 3);

            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void TestActionCalculatorSubtraction()
        {
            var result = 0;

            Action<int, int> ActionCalculatorSubtraction = (a, b) =>
            {
                result = a - b;
            };

            ActionCalculatorSubtraction(9, 3);

            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void TestActionCalculatorMultiplication()
        {
            var result = 0;

            Action<int, int> ActionCalculatorMultiplication = (a, b) =>
            {
                result = a * b;
            };

            ActionCalculatorMultiplication(9, 3);

            Assert.That(result, Is.EqualTo(27));
        }

        [Test]
        public void TestActionCalculatorDivision()
        {
            var result = 0;

            Action<int, int> ActionCalculatorDivision = (a, b) =>
            {
                result = a / b;
            };

            ActionCalculatorDivision(9, 3);

            Assert.That(result, Is.EqualTo(3));
        }

    }
}