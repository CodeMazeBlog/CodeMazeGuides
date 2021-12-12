using DelegatesDemo.SimpleDelegate;
using NUnit.Framework;

namespace Tests
{
    public class SimpleDelegateUnitTest
    {
        
        [Test]
        public void WhenAddSelected_ThenSumIsReturned()
        {

            var result = Program.CalculatorOperation(3, 5, "add");
            
            Assert.AreEqual(8,result);
        }

        [Test]
        public void WhenSubtractSelected_ThenDifferenceIsReturned()
        {

            var result = Program.CalculatorOperation(5, 3, "subtract");

            Assert.AreEqual(2, result);
        }

        [Test]
        public void WhenMultiplySelected_ThenProductIsReturned()
        {

            var result = Program.CalculatorOperation(5, 3, "multiply");

            Assert.AreEqual(15, result);
        }

        [Test]
        public void WhenDivideSelected_ThenQuotientIsReturned()
        {

            var result = Program.CalculatorOperation(8, 2, "divide");

            Assert.AreEqual(4, result);
        }

        [Test]
        public void WhenDivideSelectedAndDivisorIsZero_ThenZeroIsReturned()
        {

            var result = Program.CalculatorOperation(8, 0, "divide");

            Assert.AreEqual(0, result);
        }
    }
}