namespace Tests;

public class DeveloperUnitTest
{
    [Fact]
    public void GivenFirstAndLastName_WhenCreateMethodIsInvoked_ThenAValidDeveloperInstanceIsCreated()
    {
        //Arrange
        var firstName = "John";
        var lastName = "Doe";
        
        //Act
        var actualInstance = Developer.Create(firstName, lastName);

        //Assert
        actualInstance.Should().BeOfType<Developer>();
        actualInstance.FirstName.Should().Be(firstName);
        actualInstance.LastName.Should().Be(lastName);
    }

    [Fact]
    public void GivenACommaSeperatedFirstNameAndLastName_WhenParseMethodIsInvoked_ThenAValidDeveloperInstanceIsCreated()
    {
        //Arrange
        var inputToBeParsed = "John,Doe";
        var expectedFirstName = "John";
        var expectedLastName = "Doe";

        //Act
        var actualInstance = Developer.Parse(inputToBeParsed, null);

        //Assert
        actualInstance.Should().BeOfType<Developer>();
        actualInstance.FirstName.Should().Be(expectedFirstName);
        actualInstance.LastName?.Should().Be(expectedLastName);
    }

    [Theory]
    [InlineData("John")]
    [InlineData("John,Doe,Senior")]
    [InlineData("")]
    public void GivenInvalidFirstNameLastNameCombo_WhenParseMethodIsInvoked_ThenFormatExceptionIsRaised(string inputToBeParsed)
    {
        //Arrange
        var expectedExceptionMessage = "Expected FirstName,LastName format.";

        //Act
        Action parse = () => Developer.Parse(inputToBeParsed, null);

        //Assert
        parse.Should().Throw<FormatException>().WithMessage(expectedExceptionMessage);
    }

    [Fact]
    public void GivenFirstNameAndLastName_WhenTryParseMethodIsInvoked_ThenAValidDeveloperInstanceIsCreated()
    {
        //Arrange
        var inputToBeParsed = "Jane,Doe";
        var expectedFirstName = "Jane";
        var expectedLastName = "Doe";

        //Act
        var parseResult = Developer.TryParse(inputToBeParsed, null, out var actualInstance);

        //Assert
        parseResult.Should().BeTrue();
        actualInstance.Should().NotBeNull();
        actualInstance.FirstName.Should().Be(expectedFirstName);
        actualInstance.LastName.Should().Be(expectedLastName);
    }

    [Theory]
    [InlineData("Jane")]
    [InlineData("Jane,Doe,Senior")]
    [InlineData("")]
    public void GivenInvalidFirstNameLastNameCombo_WhenTryParseMethodIsInvoked_ThenParsingFails(string inputToBeParsed)
    { 
        //Act
        var parseResult = Developer.TryParse(inputToBeParsed, null, out var actualInstance);

        //Assert
        parseResult.Should().BeFalse();
    }
}