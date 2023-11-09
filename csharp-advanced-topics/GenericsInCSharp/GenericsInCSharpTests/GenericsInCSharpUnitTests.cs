using GenericsInCSharp;
using System.Collections;

namespace GenericsInCSharpTests
{
    delegate T ArithmeticDelegates<T>(T num1, T num2);

    [TestClass]
    public class GenericsInCSharpUnitTests
    {
        [TestMethod]
        public void GivenTwoNumbers_WhenGenericDelegatesInvoked_ThenReturnCorrectSum()
        {
            var delegateObj = new GenericDelegates();
            var addition = new ArithmeticDelegates<int>(delegateObj.AdditionFunc);
            var num1 = 5;
            var num2 = 10;

            var sum = addition(num1, num2);

            Assert.AreEqual(sum, 15);
            Assert.IsInstanceOfType(sum, typeof(int));
        }

        [TestMethod]
        public void GivenTwoNumbers_WhenGenericDelegatesInvoked_ThenReturnCorrectMultiplication()
        {
            var delegateObj = new GenericDelegates();
            var multiplication = new ArithmeticDelegates<int>(delegateObj.MultiplicationFunc);
            var num1 = 5;
            var num2 = 10;

            var sum = multiplication(num1, num2);

            Assert.AreEqual(sum, 50);
            Assert.IsInstanceOfType(sum, typeof(int));
        }

        [TestMethod]
        public void GivenGenericArray_WhenArrayIsIntantiated_ThenCheckInstanceType()
        {
            var intArray = new GenericArray<int>(5);
            var guidArray = new GenericArray<Guid>(5);
            var rand = new Random();

            for (int i = 0; i < 5; i++) 
            {
                intArray.InsertValue(i, rand.Next());
            }

            for (int i = 0; i < 5; i++)
            {
                guidArray.InsertValue(i, Guid.NewGuid());
            }
            
            Assert.IsInstanceOfType(intArray.RetrieveValue(1), typeof(int));
            Assert.IsInstanceOfType(guidArray.RetrieveValue(1), typeof(Guid));
        }

        [TestMethod]
        public void GivenGenericSwapMethod_WhenMethodIsInvoked_ThenReturnExpectedResults()
        {
            var firstInt = 1;
            var lastInt = 9;
            var firstChar = 'a';
            var lastChar = 'z';
            var integerObj = new GenericMethods<int>();
            var charObj = new GenericMethods<char>();

            integerObj.SwapElements(ref firstInt, ref lastInt);
            charObj.SwapElements(ref firstChar, ref lastChar);

            Assert.AreEqual(firstInt, 9);
            Assert.AreEqual(lastInt, 1);
            Assert.AreEqual(firstChar, 'z');
            Assert.AreEqual(lastChar, 'a');
        }
    }
}