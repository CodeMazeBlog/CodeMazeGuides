using ActAndFuncDelegates;
using Xunit;

namespace Tests
{
    public class ActAndFuncDelegatesUnitTests
    {
        [Fact]
        public void WhenIntIsSentToMultDel_ThenDelExecutesReferencedMethod()
        {
            MultDel powTwoDel = Program.SquareNumber;
            var res = powTwoDel(2);

            Assert.Equal(4, res);
        }

        [Fact]
        public void WhenMultDelConvertedToFuncMethod_ThenDelExecutesReferencedMethod()
        {
            Func<int, int> powTwoFuncDel = Program.SquareNumber;
            var res = powTwoFuncDel(2);

            Assert.Equal(4, res);
        }

        [Fact]
        public void WhenMultDelConvertedToFuncMethod_ThenDelInvListEqualsOne()
        {
            Func<int, int> powTwoFuncDel = Program.SquareNumber;
            var invList = powTwoFuncDel.GetInvocationList();

            Assert.Single(invList);
        }

        [Theory]
        [InlineData("Name", Language.English, "Hello, Name\n")]
        [InlineData("Name", Language.French, "Bonjour, Name\n")]
        [InlineData("Name", Language.Spanish, "Hola, Name\n")]
        public void WhenUserLanguageAssignedByGreetUser_ThenSwitchStatementAssignsCorrectReferenceMethod(string name,
            Language language, string expOutput)
        {
            var user = new User { Name = name, UserLanguage = language };
            var appProf = new AppProfile(user);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            appProf.GreetUser();
            var output = stringWriter.ToString();

            Assert.Equal(expOutput, output);
        }

        [Fact]
        public void WhenGreetUserActionDel_ThenDelInvocationListEqualsOne()
        {
            var user = new User { Name = "Name", UserLanguage = Language.English };
            var profile = new AppProfile(user);
            Action action = profile.GreetUser;
            var invList = action.GetInvocationList();

            Assert.Single(invList);
        }
    }
}
