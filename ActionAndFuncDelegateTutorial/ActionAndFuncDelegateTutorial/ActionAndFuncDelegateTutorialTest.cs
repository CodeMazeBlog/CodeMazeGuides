using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ActionAndFuncDelegateTutorial
{
    public class ActionAndFuncDelegateTutorialTest
    {
        public static int AreaOfRectangle(int length, int breath)
        {
            return length * breath;
        }

        public static void WelcomeUser(string name)
        {
            Console.WriteLine("Hello " + name + " how are you doing today?");
        }

        [Fact]
        public void TestFuncDelegate()
        {
            Func<int, int, int> areaOfRectangle = AreaOfRectangle;
            var result = areaOfRectangle(10, 15);
            Assert.Equal(150, result);
        }

        [Fact]
        public void TestActionDelegate()
        {
            Action<string> welcomeUser = WelcomeUser;
            var result = welcomeUser.GetInvocationList();
            Assert.NotNull(result);
        }
    }
}
