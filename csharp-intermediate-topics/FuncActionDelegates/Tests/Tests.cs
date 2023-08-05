using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
	[TestClass]
	public class Tests
	{
        static int powerActionResult = 0;
        static int powerActionAnonymousResult = 0;
        static int powerActionLambdaResult = 0;

        Func<int, int, int> Power = PoweredTo;

        Func<int, int, int> PowerAnonymous = delegate (int baseNumber, int exponent)
        {
            return (int)Math.Pow(baseNumber, exponent);
        };

        Func<int, int, int> PowerLambda = (int baseNumber, int exponent) =>
            (int)Math.Pow(baseNumber, exponent);

        Action<int, int> PowerAction = PoweredToAction;

        Action<int, int> PoweredActionAnonymous = delegate (int baseNumber, int exponent)
        {
            powerActionAnonymousResult = (int)Math.Pow(baseNumber, exponent);
        };

        Action<int, int> PoweredActionLambda = (int baseNumber, int exponent) =>
            powerActionLambdaResult = (int)Math.Pow(baseNumber, exponent);


        [TestMethod]
        public void WhenFuncIsCalled_ThenExecutesDelegate()
        {
            var funcValue = Power(2, 5);
            var result = (int)Math.Pow(2, 5);
            Assert.AreEqual(funcValue, result);

            var funcAnonymousValue = PowerAnonymous(3, 6);
            result = (int)Math.Pow(3, 6);
            Assert.AreEqual(funcAnonymousValue, result);

            var funcLambdaValue = PowerLambda(2, 10);
            result = (int)Math.Pow(2, 10);
            Assert.AreEqual(funcLambdaValue, result);
        }

        [TestMethod]
        public void WhenActionIsCalled_ThenExecutesDelegate()
        {
            PowerAction(2, 5);
            var result = (int)Math.Pow(2, 5);
            Assert.AreEqual(powerActionResult, result);

            PoweredActionAnonymous(3, 6);
            result = (int)Math.Pow(3, 6);
            Assert.AreEqual(powerActionAnonymousResult, result);

            PoweredActionLambda(2, 10);
            result = (int)Math.Pow(2, 10);
            Assert.AreEqual(powerActionLambdaResult, result);
        }

        static int PoweredTo(int baseNumber, int exponent)
        {
            return (int)Math.Pow(baseNumber, exponent);
        }

        static void PoweredToAction(int baseNumber, int exponent)
        {
            powerActionResult = (int)Math.Pow(baseNumber, exponent);
        }
    }
}
