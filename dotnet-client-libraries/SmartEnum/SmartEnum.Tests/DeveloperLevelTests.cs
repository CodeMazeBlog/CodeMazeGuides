using Ardalis.SmartEnum;
using FluentAssertions;

namespace SmartEnum.Tests
{
    public class DeveloperLevelTests
    {
        [Theory]
        [InlineData("Junior", 75)]
        [InlineData("Regular", 125)]
        [InlineData("Senior", 175)]
        public void GivenValidLevel_WhenDeveloperLevelIsCreated_ThenCorrectProductivityIsReturned(string level, double productivity)
        {
            var dev = DeveloperLevel.FromName(level);

            dev.Should().NotBeNull();
            dev.Productivity.Should().Be(productivity);
        }

        [Fact]
        public void GivenInvalidLevel_WhenDeveloperLevelIsCreated_ThenSmartEnumNotFoundExceptionIsThrown()
        {
            Action action = () => DeveloperLevel.FromName("Architect");

            action.Should().Throw<SmartEnumNotFoundException>();
        }
    }
}