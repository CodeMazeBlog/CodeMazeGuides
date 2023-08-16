using System.Collections.Generic;
using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Entities;
using ActionAndFuncDelegates.IO;
using Moq;
using Xunit;

namespace Tests
{
    public class ExampleMethodsTest
    {
        Mock<IAppConsole> appConsoleMock;
        ExampleMethods exMethods;

        public ExampleMethodsTest()
        {
            appConsoleMock = new Mock<IAppConsole>();
            exMethods = new ExampleMethods(appConsoleMock.Object);
        }

        [Fact]
        public void GivenAUser_WhenPrintingUsername_ThenSuccessfullFormatted()
        {
            // arrange
            var fakeUser = new User() { Name = "Pablo", Age = 30 };

            // act
            exMethods.PrintUserName(fakeUser);

            // assert
            appConsoleMock.Verify(t => t.WriteLine($"\t\tThe username is {fakeUser.Name}"), Times.Once());
        }

        [Fact]
        public void GivenAUser_WhenPrintingUserData_ThenSuccessfullFormatted()
        {
            // arrange
            var fakeUser = new User() { Name = "Pablo", Age = 30 };

            // act
            exMethods.PrintAllUserData(fakeUser);

            // assert
            appConsoleMock.Verify(t => t.WriteLine($"\t\t{fakeUser.Name} is {fakeUser.Age} years old"), Times.Once());
        }

        [Fact]
        public void GivenAUser_WhenPrintingUserAgeDays_ThenSuccessfullFormatted()
        {
            // arrange
            var fakeUser = new User() { Name = "Pablo", Age = 30 };

            // act
            exMethods.PrintUserDaysOfLife(fakeUser);

            // assert
            appConsoleMock.Verify(t => t.WriteLine($"\t\t{fakeUser.Name} is {fakeUser.Age * 365} days old"), Times.Once());
        }

        public static IEnumerable<object[]> GetUsers()
        {
            yield return new object[]
            {
                new User() { Name = "Pablo", Age = 30 },
                "\t\tPablo is an adult"
            };
            yield return new object[]
            {
                new User() { Name = "Theo", Age = 6 },
                "\t\tTheo is a child"
            };
        }

        [Theory]
        [MemberData(nameof(GetUsers))]
        public void GivenAUser_WhenIsAnAdult_ThenOutputAdultMessage(User fakeUser, string expectedMessage)
        {
            // arrange

            // act
            var result = exMethods.PrintIfUserIsAdultOrChild(fakeUser);

            // assert
            Assert.Equal(result, expectedMessage);
        }
    }
}
