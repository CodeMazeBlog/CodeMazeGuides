using System;
using Xunit;

namespace FuncAndActionTest
{
    public class UnitTest1
    {
        public delegate int DelegateMethod(int a, int b);

        public static int DisplayResult(int a, int b)
        {
            return a + b;
        }
        public static int CalculateValue(int a, int b)
        {
            return a * b;
        }

        
        public static void PrintValue(int number)
        {
            Console.WriteLine(number);
        }

        [Fact]
        public void FunctionTest()
        {
            var func = new Func<int, int, int>(CalculateValue);
            var result = func(2, 5);
            Assert.Equal(10, result);           

        }

        [Fact]
        public void ActionTest()
        {
            var action = new Action<int>(PrintValue);            
            var invocationList = action.GetInvocationList();
            Assert.Single(invocationList);

        }
        [Fact]
        public void DelegateTest()
        {
            DelegateMethod d1 = new DelegateMethod(DisplayResult);
            var result = d1(3, 5);
            Assert.Equal(8, result);
        }

    }
}