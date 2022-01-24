using System;
using Xunit;
using FunctionDelegates;

namespace Tests
{
    public static class FunctionDelegate_Test
    {
        [Fact]
        public static void WhenInvoke_ThenCheckEvenOrOdd()
        {
            var integer1 = 2;
            var integer2 = 5;
            var result=  Program.SumTwoValue(integer1, integer2);
            bool condition = false;
            if (result=="Even")
            {
                condition = false;
            }
            else if (result == "Odd")
            {
                condition = true;
            }
            Assert.True(condition);
        }
        
    }
}
