
using System;
using Xunit;

namespace FuncAndActionTest
{ 
    public class FuncAndActionTest
    {
        public delegate int DelegateMethod(int a, int b);               

        [Fact]
        public void FunctionTest()
        {                     
            var func = new Func<int, int, int>(Program.CalculateValue);
            var result = func(2, 5);
            Assert.Equal(10, result);           

        }

        [Fact]
        public void ActionTest()
        {
            var action = new Action<int>(Program.PrintValue);            
            var invocationList = action.GetInvocationList();
            Assert.Single(invocationList);

        }

        [Fact]
        public void DelegateTest()
        {
            DelegateMethod d1 = new DelegateMethod(Program.DisplayResult);
            var result = d1(3, 5);
            Assert.Equal(8, result);
        }

    }
}