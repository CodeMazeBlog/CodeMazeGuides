using ActionAndFuncCsharp;
using System;
using Xunit;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void DisplayText_Test()
        {
            try
            {
                var actionDelegate = new ActionDelegate();
                var displayText = new Action(actionDelegate.DisplayText);
                displayText();    
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void DisplayNumbers_Test()
        {
            try
            {
                var actionDelegate = new ActionDelegate();
                var displayNumbers = new Action<int, int>(actionDelegate.DisplayNumbers);
                displayNumbers(10,20);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void DisplayMessage_Test()
        {
            try
            {
                var actionDelegate = new ActionDelegate();
                var displayMsg = new Action<string>(actionDelegate.DisplayMessage);
                displayMsg("Hassan Iftikhar"); 
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void whenNumbersSent_Displaysum()
        {
            var funcDelegate = new FuncDelegate();

            var sum = new Func<int, int, string>(funcDelegate.DisplaySum);
            var addition = sum(2, 3);  
            Assert.Equal($"Sum of 2 and 3 is: 5", addition);
        }

        [Fact]
        public void TakePower_Test()
        {
            var funcDelegate = new FuncDelegate();

            var power = new Func<int, int, int>(funcDelegate.TakePower);
            var pow = power(2, 5);  
            Assert.Equal($"32", pow.ToString());
        }

        [Fact]
        public void AppendString_Test()
        {
            var funcDelegate = new FuncDelegate();

            var stringConcat = new Func<string, string, string>(funcDelegate.StringAppend);
            var appendText = stringConcat("Hassan", "Iftikhar");    //Parameter:2 , Returns: string
            Assert.Equal($"HassanIftikhar", appendText.ToString());
        }
    }
}
