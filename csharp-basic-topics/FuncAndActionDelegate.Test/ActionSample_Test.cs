using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegate.Test
{
    using Xunit;

    public class ActionSampleTests
    {
        [Fact]
        public void WhenTimeOfDayIsMorning_GreetUserShouldDisplayMorningGreeting()
        {
            // Arrange
            string name = "John";
            string timeOfDay = "Morning";
            string expectedGreeting = $"Good Morning, {name}";

            // Act
            using StringWriter sw = new();
            Console.SetOut(sw);
            ActionSample.GreetUser(name, timeOfDay);
            string actualOutput = sw.ToString().Trim();

            // Assert
            Assert.Equal(expectedGreeting, actualOutput);
        }

        [Fact]
        public void WhenTimeOfDayIsAfternoon_GreetUserShouldDisplayAfternoonGreeting()
        {
            // Arrange
            string name = "Jane";
            string timeOfDay = "Afternoon";
            string expectedGreeting = $"Good Afternoon, {name}";

            // Act
            using StringWriter sw = new();
            Console.SetOut(sw);
            ActionSample.GreetUser(name, timeOfDay);
            string actualOutput = sw.ToString().Trim();

            // Assert
            Assert.Equal(expectedGreeting, actualOutput);
        }
    }

}
