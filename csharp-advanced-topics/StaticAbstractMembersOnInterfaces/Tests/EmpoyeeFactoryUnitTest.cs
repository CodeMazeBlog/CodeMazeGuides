namespace Tests;

public class EmpoyeeFactoryUnitTest
{
    [Fact]
    public void GivenFirstAndLastName_WhenCreateMethodIsInvoked_ThenFactoryCreatesAValidInstance()
    {
        //Arrange
        var firstName = "John";
        var lastName = "Doe";
        
        //Act
        var actualInstance = GenericEmployeeFactory.CreateEmployee<Developer>(firstName, lastName);

        //Assert
        actualInstance.Should().BeOfType<Developer>();
        actualInstance.FirstName.Should().Be(firstName);
        actualInstance.LastName.Should().Be(lastName);
    }
}