namespace PrimaryConstructorsForClassesAndStructs.Tests;

public class DoctorTests
{
    [Fact]
    public void WhenConstructorIsInvoked_ThenAllPropertiesAreAssigned()
    {
        // Arrange
        var name = "Gregory House";

        // Act
        var doctor = new Doctor(name);

        // Assert
        doctor.Name.Should().NotBeNull().And.Be(name);
        doctor.IsOverworked.Should().BeFalse();
    }

    [Fact]
    public void GivenMoreThanFivePatients_WhenIsOverworkedIsInvoked_ThenTrueIsReturned()
    {
        // Arrange
        var name = "Gregory House";
        var doctor = new Doctor(name);

        // Act
        for (int i = 0; i < 10; i++)
        {
            doctor.AddPatient(string.Empty);
        }

        // Assert
        doctor.IsOverworked.Should().BeTrue();
    }
}