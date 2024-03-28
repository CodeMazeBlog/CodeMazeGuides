namespace ImprovePerformanceWithSourceGeneratedRegEx.Tests;

public class PasswordValidatorTests
{
    private const string ValidPassword = "c0d3-MaZ3-Pa55w0rd";
    private const string InvalidPassword = "Code-Maze-Password";

    #region ValidatePasswordWithRegularRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithRegularRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithRegularRegEx(ValidPassword);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithRegularRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithRegularRegEx(InvalidPassword);

        // Assert
        result.Should().BeFalse();
    }
    #endregion

    #region ValidatePasswordWithCompiledRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithCompiledRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithCompiledRegEx(ValidPassword);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithCompiledRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithCompiledRegEx(InvalidPassword);

        // Assert
        result.Should().BeFalse();
    }
    #endregion

    #region ValidatePasswordWithSourceGeneratedRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithSourceGeneratedRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(ValidPassword);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithSourceGeneratedRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(InvalidPassword);

        // Assert
        result.Should().BeFalse();
    }
    #endregion
}