using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tests
{
    public class CustomDelegatesUnitTest
    {
        [Fact]
        public void WhenGetsMessage_ThenDisplaysIt()
        {
            CustomDelegates customDelegate = new CustomDelegates();
            Thread.Sleep(1000);

            string message = "This is a single message!";
            string expected = string.Format("This is a single message!{0}", Environment.NewLine);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                customDelegate.DisplayMessage(message);

                Assert.Equal(expected, sw.ToString());
            }
        }

        [Fact]
        public void WhenGetsNumber_ThenReturnsItsSquare()
        {
            CustomDelegates customDelegate = new CustomDelegates();

            int expected = 16;
            int actual = customDelegate.ReturnValue(4);

            Assert.Equal(expected, actual);
        }
    }
}
