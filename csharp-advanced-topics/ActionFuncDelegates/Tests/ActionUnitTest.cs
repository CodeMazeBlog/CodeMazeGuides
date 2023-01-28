using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tests
{
    public class ActionUnitTest
    {
        [Fact]
        public void WhenGetsMessage_ThenDisplaysIt()
        {
            ActionDelegate actionDelegate = new ActionDelegate();
            Thread.Sleep(2000);

            string message = "This is a single message!";
            string expected = string.Format("This is a single message!{0}", Environment.NewLine);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                actionDelegate.DisplayMessage(message);

                Assert.Equal(expected,sw.ToString());
            }
        }

        [Fact]
        public void WhenGetsMessages_ThenDisplaysThem()
        {
            ActionDelegate actionDelegate = new ActionDelegate();

            string message1 = "This is first message!";
            string message2 = "This is second message! ";
            string expected = string.Format(message1+message2+"{0}", Environment.NewLine);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                actionDelegate.DisplayMessages(message1,message2);

                Assert.Equal(expected, sw.ToString());
            }
        }
    }
}
