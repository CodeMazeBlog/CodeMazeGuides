namespace PrimaryConstructorsForClassesAndStructs.Tests;

public class PointTests
{
    [Fact]
    public void WhenConstructorIsInvoked_ThenAllPropertiesAreAssigned()
    {
        // Arrange
        var x = 5.0;
        var y = 6.5;

        // Act
        var point = new Point(x, y);

        // Assert
        point.X.Should().Be(x);
        point.Y.Should().Be(y);
    }
}
