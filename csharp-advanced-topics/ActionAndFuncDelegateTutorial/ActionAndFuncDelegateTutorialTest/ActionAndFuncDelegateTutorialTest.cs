using ActionAndFuncDelegateTutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegateTutorialTest
{
    public class ActionAndFuncDelegateTutorialTest
    {
        [Fact]
        public void FuncDelegateTest()
        {
            Func<int, int, int> areaOfRectangle = Program.AreaOfRectangle;
            var result = areaOfRectangle(10, 15);
            Assert.Equal(150, result);
        }

        [Fact]
        public void ActionDelegateTest()
        {
            Action<string> welcomeUser = Program.WelcomeUser;
            var result = welcomeUser.GetInvocationList();
            Assert.NotNull(result);
        }
    }
}
