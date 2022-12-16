using Moq;
using Xunit;

namespace Tests;

public class ActionAndFuncDelegatesTest
{
    [Fact]
    public void WhenForEachIsInvoked_ThenDelegateInvokedExactlyTimes()
    {
        var fooMock = new Mock<Action<string>>();

        new List<string> { "Hello", "World", "!" }.ForEach(fooMock.Object);

        fooMock.Verify(f => f(It.IsAny<string>()), Times.Exactly(3));
    }

    [Fact]
    public void WhenFuncIsInvoked_ThenAllStringsToUpper()
    {
        var words = new[] { "code", "maze" };

        Func<string, string> toUpper = input => input.ToUpper();
        var wordsInUppercase = words.Select(toUpper);

        Assert.Equal(new[] { "CODE", "MAZE" }, wordsInUppercase.ToArray());
    }
}