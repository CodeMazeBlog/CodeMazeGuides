using System.Collections.Generic;
using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Entities;
using ActionAndFuncDelegates.Extensions;
using ActionAndFuncDelegates.IO;
using Moq;
using Xunit;

namespace Tests.Extensions
{
    public class UserExtensionTest
    {
        [Fact]
        public void GivenAUser_WhenPrintingUsername_ThenSuccessfullFormatted()
        {
            // arrange
            var fakeUsers = new List<User>()
            {
                new() { Name = "Pablo", Age = 30 },
                new() { Name = "Theo", Age = 6 },
                new() { Name = "Matteo", Age = 3 }
            };

            var mockedDelegate = new Mock<ExampleDelegates.PrintUserDataDelegate>();
            
            // act
            fakeUsers.ExecutePrint(mockedDelegate.Object);

            // assert
            mockedDelegate.Verify(t => t(It.IsAny<User>()), Times.Exactly(fakeUsers.Count));
        }
    }
}