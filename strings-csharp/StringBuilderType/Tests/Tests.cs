namespace Tests;

using StringBuilderType;
using System;
using Xunit;

public class Tests
{
    public static readonly StringBuilderMethods stringBuilderMethods = new StringBuilderMethods();

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndAppend_ThenReturnAStringBuilder()
    {
        //Arrange
        var text = "Appending a value to StringBuilder";

        //Act
        var response = stringBuilderMethods.Append(text);

        //Assert
        Assert.Equal(text.Length, response.Length);
    }

    [Fact]
    public void WhenCallingMethodWillDefineAndAppend_ThenReturnStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.Append();

        //Assert
        Assert.NotNull(response);
        Assert.InRange(response.Length,0, response.MaxCapacity);
    }

    [Fact]
    public void GivenAString_WhenStringBuilderMaxValueIsAttained_ThenThrowAnException()
    {
        //Arrange
        var text = "Appending a value to StringBuilder";

        //Act
        var response = Assert.Throws<OutOfMemoryException>(()=> stringBuilderMethods.Append(text, int.MaxValue));
      
        //Assert
        Assert.NotNull(response);
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndAppendNewLine_ThenReturnStringBuilde()
    {
        //Arrange
        var text = "Appending a value to StringBuilder";

        //Act
        var response = stringBuilderMethods.AppendLine(text);

        //Assert
        Assert.EndsWith(Environment.NewLine, response.ToString());
    }

    [Fact]
    public void WhenCallingMethodWillDefineAndAppendNewLine_ThenReturnStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.AppendLine();

        //Assert
        Assert.EndsWith(Environment.NewLine, response.ToString());
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndAppendFormattedString_ThenReturnStringBuilder()
    {
        //Arrange
        var text = "Adding a formatted text to StringBuilder";
        var format = "{0,-10}";

        //Act
        var response = stringBuilderMethods.AppendFormat(format, text);

        //Assert
        Assert.Equal(string.Format(text, format), response.ToString());
    }

    [Fact]
    public void WhenCallingMethodWillDefineAndAppendFormattedString_ThenReturnStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.AppendFormat();

        //Assert
        Assert.NotNull(response);
        Assert.InRange(response.Length, 0, response.MaxCapacity);
    }

    [Fact]
    public void WhenCallingMethodWillDefineAndInsertSomeString_ThenReturnStringBuilderWithStringInsertedAtHead()
    { 
        //Act
        var response = stringBuilderMethods.Insert();

        //Assert
        Assert.NotNull(response);
        Assert.InRange(response.Length, 0, response.MaxCapacity);
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndInsertSomeString_ThenReturnStringBuilderWithStringInsertedAtHead()
    {
        //Arrange
        var text = "I like chocolates";

        //Act
        var response = stringBuilderMethods.Insert(text, "Moreover", 0);

        //Assert
        Assert.StartsWith("Moreover", response.ToString());
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndInsertSomeString_ThenReturnStringBuilderWithStringInsertedAtTail()
    {
        //Arrange
        var text = "I like chocolates";

        //Act
        var response = stringBuilderMethods.Insert(text, "especially the dark type", text.Length);

        //Assert
        Assert.EndsWith("dark type", response.ToString());
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillDefineAndRemoveSomeString_ThenReturnStringBuilder()
    {
        //Arrange
        var text = "I like chocolates and fruits";

        //Act
        var response = stringBuilderMethods.Remove(text, "and");

        //Assert
        Assert.DoesNotContain("and", response.ToString());
    }

    [Fact]
    public void WhenCallingMethodWillDefineAndRemoveSomeString_ThenReturnStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.Remove();

        //Assert
        Assert.NotNull(response);
        Assert.InRange(response.Length, 0, response.MaxCapacity);
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillCreateAndReplaceContents_ThenReturnStringBuilder()
    {
        //Arrange
        var text = "I like chocolates and fruits";

        //Act
        var response = stringBuilderMethods.Replace(text, "like", "love");

        //Assert
        Assert.DoesNotContain("like", response.ToString());
        Assert.Contains("love", response.ToString());
    }

    [Fact]
    public void WhenCallingMethodWillCreateAndReplaceContents_ThenReturnStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.Replace();

        //Assert
        Assert.NotNull(response);
        Assert.InRange(response.Length, 0, response.MaxCapacity);
    }

    [Fact]
    public void GivenAString_WhenCallingMethodWillCreateAndClearContents_ThenReturnTheLengthOfStringBuilder()
    {
        //Arrange
        var text = "I like chocolates and fruits";
        var sb = stringBuilderMethods.Append(text);

        //Act
        var response = stringBuilderMethods.Clear(sb);

        //Assert
        Assert.StrictEqual(0, response);
    }

    [Fact]
    public void WhenCallingMethodWillCreateAndClearContents_ThenReturnTheLengthOfStringBuilder()
    {
        //Act
        var response = stringBuilderMethods.Clear();

        //Assert
        Assert.StrictEqual(0, response);
    }

    [Fact]
    public void GivenAString_WhenConvertedToStringBuilder_ThenReturnContentsAsString()
    {
        //Arrange
        var text = "I like chocolates and fruits";
        var sb = stringBuilderMethods.Append(text);

        //Act
        var response = stringBuilderMethods.ConvertToString(sb);

        //Assert
        Assert.Equal(text, response);
    }
}

