using FluentAssertions;

namespace MockingWithNSubstitute.Tests
{
    public class UserTests
    {
        [Fact]
        public void WhenConstructorIsInvoked_ThenValidInstanceIsReturned()
        {
            // Arrange
            var name = "name";
            var email = "email";

            // Act
            var user = new User(name, email);

            // Assert
            user.Name.Should().Be(name);
            user.Email.Should().Be(email);
            user.Id.Should().NotBeEmpty();
        }
    }
}