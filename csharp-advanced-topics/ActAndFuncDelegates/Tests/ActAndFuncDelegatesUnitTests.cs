using ActAndFuncDelegates;
using Xunit;

namespace Tests
{
    delegate int MultDel(int inInt);

    public class ActAndFuncDelegatesUnitTests
    {
        private static int SquareNumber(int inputInt) => inputInt * inputInt;

        private static string GreetingsEnglish(string userName) => $"Hello, {userName}";
        private static string GreetingsSpanish(string userName) => $"Hola, {userName}";
        private static string GreetingsFrench(string userName) => $"Bonjour, {userName}";

        private static string GreetUser(User user)
        {
            Func<string, string> greetingTarget;

            switch (user.UserLangage)
            {
                case Language.English:
                    greetingTarget = GreetingsEnglish;
                    break;
                case Language.Spanish:
                    greetingTarget = GreetingsSpanish;
                    break;
                case Language.French:
                    greetingTarget = GreetingsFrench;
                    break;
                default:
                    greetingTarget = GreetingsEnglish;
                    break;
            }
            return greetingTarget(user.Name);
        }

        [Fact]
        public void WhenIntIsSentToMultDel_DelExecutesReferencedMethod()
        {
            MultDel powTwoDel = SquareNumber;
            var res = powTwoDel(2);

            Assert.Equal(4, res);
        }

        [Fact]
        public void WhenMultDelConvertedToFuncMethod_DelExecutesReferencedMethod()
        {
            Func<int, int> powTwoFuncDel = SquareNumber;
            var res = powTwoFuncDel(2);

            Assert.Equal(4, res);
        }

        [Fact]
        public void WhenMultDelConvertedToFuncMethod_DelInvListEqualsOne()
        {
            Func<int, int> powTwoFuncDel = SquareNumber;
            var invList = powTwoFuncDel.GetInvocationList();

            Assert.Single(invList);
        }
        [Theory]
        [InlineData("Name", Language.English, "Hello, Name")]
        [InlineData("Name", Language.French, "Bonjour, Name")]
        [InlineData("Name", Language.Spanish, "Hola, Name")]
        public void WhenUserLanguageAssignedByGreetUser_SwitchStatementAssignsCorrectReferenceMethod(string name,
            Language language, string expOutput)
        {
            var user = new User { Name = name, UserLangage = language };
            var greeting = GreetUser(user);

            Assert.Equal(expOutput, greeting);
        }

        [Fact]
        public void WhenGreetUserActionDel_DelInvocationListEqualsOne()
        {
            var user = new User { Name = "Name", UserLangage = Language.English };
            var profile = new AppProfile(user);
            Action action = profile.GreetUser;
            var invList = action.GetInvocationList();

            Assert.Single(invList);
        }
    }
}
