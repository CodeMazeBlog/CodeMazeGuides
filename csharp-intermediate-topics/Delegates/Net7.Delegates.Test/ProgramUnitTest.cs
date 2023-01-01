using Moq;
using Net7.Delgates;

namespace Net7.Delegates.Tests
{
    public class ProgramUnitTest
    {

        [Fact]
        public void WhenDisplayMessageDelegateCall_ThenVerifyDisplayMessageDelegateBehaviour()
        {
            // arrange
            var mockGetNames = new Mock<Program.DisplayMessage>();
            mockGetNames.Setup(_ => _(It.IsAny<string>())).Verifiable();

            // act
            mockGetNames.Object.Invoke("Hello delegates!");

            // assert
            mockGetNames.Verify(_ => _.Invoke("Hello delegates!"), Times.Once);
        }

        [Theory]
        [InlineData("Kanhaya", "Tyagi", "Kanhaya Tyagi")]
        [InlineData("Code", "Maze", "Code Maze")]
        public void WhenFirstAndLastNameInGetFullName_ThenGetFullName(string firstName, string lastName, string fullName)
        {
            // arrange

            // act
            var result = Program.GetFullName(firstName, lastName);
            // assert
            Assert.Equal(fullName, result);
        }

        [Theory]
        [InlineData("Delegates in c#")]
        [InlineData("Welcome to code maze")]

        public void WhenMessagePassedOnPrintMethod_ThenVerifyingSuccessBehaviour(string message)
        {
            try
            {
                // arrange

                // act
                Program.Print(message);

                // assert
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }

    }
}
