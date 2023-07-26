using ActionAndFuncDelegates.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegate.Tests
{
    public class ActionDelegateServiceUnitTests
    {
        public ActionDelegateServiceUnitTests()
        {
                
        }


        [Fact]
        public void GreetAction_GivenValidName_WhenGreetIsCalled_ThenShouldGreetUser()
        {
            // Arrange
            var actionDelegateService = new ActionDelegateService();
            string expectedName = "John";
            string expectedGreeting = $"Hello, {expectedName}! Welcome to our the maze.";

            // Act
            string actualGreeting = string.Empty;
            actionDelegateService.GreetAction = (name) =>
            {
                actualGreeting = $"Hello, {name}! Welcome to our the maze.";
            };

            actionDelegateService.Greet(expectedName);

            // Assert
            Assert.Equal(expectedGreeting, actualGreeting);
        }

        [Fact]
        public void EventRegistrationAction_GivenValidEventNames_WhenRegisterForEventIsCalled_ThenShouldDisplayRegisteredEvents()
        {
            // Arrange
            var actionDelegateService = new ActionDelegateService();
            List<string> expectedEventNames = new List<string> { "Event1", "Event2", "Event3" };
            string expectedUserName = "John";
            string expectedOutput = $"'{expectedUserName}' has registered for the following events: \n- Event1\n- Event2\n- Event3";

            // Act
            string actualOutput = string.Empty;
            actionDelegateService.EventRegistrationAction = (eventNames, userName) =>
            {
                actualOutput = $"'{userName}' has registered for the following events: ";
                foreach (var eventName in eventNames)
                {
                    actualOutput += $"\n- {eventName}";
                }
            };

            actionDelegateService.RegisterForEvent(expectedEventNames, expectedUserName);

            // Assert
            Assert.Equal(expectedOutput, actualOutput);

        }
    }



}
