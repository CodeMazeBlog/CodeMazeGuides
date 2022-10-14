using ActionAndFuncDelegatesInCSharp;

namespace Tests
{
    public class Tests
    {
        private double GetRoot(double value)
        {
            return Math.Sqrt(value);
        }

        private double GetSquare(double value)
        {
            return Math.Pow(value, 2);
        }

        [Test]
        public void WhenValue100_ThenSquare10000()
        {
            var value = 100;
            var result = Methods.GetProcessResult(value, (double value) => Console.WriteLine("Calculating a square of {0}.", value), new Func<double, double>(GetSquare)); ;
            Assert.That(result, Is.EqualTo(10000));
        }

        [Test]
        public void WhenValue100_ThenRoot10()
        {
            var value = 100;
            var result = Methods.GetProcessResult(value, (double value) => Console.WriteLine("Calculating the square root of {0}.", value), new Func<double, double>(GetRoot));
            Assert.That(result, Is.EqualTo(10));
        }
    }
}