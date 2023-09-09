using FileScopedTypesInCSharp;

namespace Tests;

public partial class FileScopedTypesUnitTest
{
    [Fact]
    public void GivenFileSopedTypeHiddenClass_WhenRender_OutputDoesNotMatch()
    {
        // Arrange
        var expectedOutput = "Rendering file scoped Hidden Class";
        var hiddenClassInstance = new HiddenClass();

        // Act
        var actualOutput = hiddenClassInstance.Render();

        // Assert
        Assert.NotEqual(actualOutput,expectedOutput);
    }

    [Fact]
    public void GivenPublicHiddenClass_WhenRender_OutputMatch()
    {
        // Arrange
        var expectedOutput = "Rendering public Hidden Class";
        var hiddenClassInstance = new HiddenClass();

        // Act
        var actualOutput = hiddenClassInstance.Render();

        // Assert
        Assert.Equal(actualOutput,expectedOutput);
    }
}