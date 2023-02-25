using FluentAssertions;

namespace SmartEnum.Tests
{
    public class DeveloperTests
    {
        [Fact]
        public void GivenValidParameters_WhenConstructorIsInvoked_ThenValidObjectIsCreated()
        {
            var name = "John";
            var level = DeveloperLevel.Regular;

            var developer = new Developer(name, level);

            developer.Should().NotBeNull();
            developer.Name.Should().Be(name);
            developer.Level.Should().Be(level);
            developer.Level.Productivity.Should().Be(level.Productivity);
        }

        [Fact]
        public void GivenValidDeveloper_WhenWriteCodeIsInvoked_ThenValidResultIsReturned()
        {
            var name = "John";
            var level = DeveloperLevel.Regular;
            var linesOfCode = 500;

            var developer = new Developer(name, level);

            developer.WriteCode(linesOfCode).Should().Be(linesOfCode / developer.Level.Productivity);
        }
    }
}
