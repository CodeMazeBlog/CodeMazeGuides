using FileScopedTypesInCSharp;

namespace Tests;

public partial class FileScopedTypesUnitTest
{
    [Fact]
    public void GivenFileSopedTypeHiddenClassInSameFile_WhenRender_OutputMatch()
    {
        // Arrange
        var expectedOutput = "Rendering file scoped Hidden Class";
        var hiddenClassInstance = new HiddenClass();

        // Act
        var actualOutput = hiddenClassInstance.Render();

        // Assert
        Assert.Equal(actualOutput,expectedOutput);
    }
}

file class HiddenClass
{
    public string Render()
    {
        return "Rendering file scoped Hidden Class";
    }
}