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
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithRegularRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithRegularRegEx(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region ValidatePasswordWithCompiledRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithCompiledRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithCompiledRegEx(ValidPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithCompiledRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithCompiledRegEx(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region ValidatePasswordWithSourceGeneratedRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithSourceGeneratedRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(ValidPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithSourceGeneratedRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegEx(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region ValidatePasswordWithStaticRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithStaticRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithStaticRegEx(ValidPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithStaticRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithStaticRegEx(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region ValidatePasswordWithNewCompiledRegEx
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithNewCompiledRegExIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithNewCompiledRegEx(ValidPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithNewCompiledRegExIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithNewCompiledRegEx(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion

    #region ValidatePasswordWithSourceGeneratedRegExProperty
    [Fact]
    public void GivenValidPassword_WhenValidatePasswordWithSourceGeneratedRegExPropertyIsInvoked_ThenTrueIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegExProperty(ValidPassword);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GivenInvalidPassword_WhenValidatePasswordWithSourceGeneratedRegExPropertyIsInvoked_ThenFalseIsReturned()
    {
        // Act
        var result = PasswordValidator.ValidatePasswordWithSourceGeneratedRegExProperty(InvalidPassword);

        // Assert
        Assert.False(result);
    }
    #endregion
}
