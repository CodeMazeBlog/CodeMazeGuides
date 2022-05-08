using System.Collections;
using Xunit;
namespace StackInCSharpTestProject;
public class Tests
{
    [Fact]
    public void WhenPushItem_ThenStackCountIncreases()
    {
        var stack = new Stack();
        var initialStackCount = stack.Count;
        stack.Push(1);
        stack.Push("test");

        Assert.Equal(initialStackCount + 2, stack.Count);
    }

    [Fact]
    public void WhenPopItem_ThenStackCountDecreases()
    {
        var stack = new Stack();
        stack.Push(1);
        stack.Push("test");

        var stackCountBeforePop = stack.Count;
        stack.Pop();

        Assert.Equal(stackCountBeforePop - 1, stack.Count);
    }

    [Fact]
    public void WhenPeekItem_ThenStackCountRemainsEqual()
    {
        var stack = new Stack();
        stack.Push(1);
        stack.Push("test");

        var stackCountBeforePeek = stack.Count;
        stack.Peek();

        Assert.Equal(stackCountBeforePeek, stack.Count);
    }

    [Fact]
    public void WhenPop_ThenTheItemIsTheLastAdded()
    {
        var stack = new Stack();
        stack.Push(1);
        stack.Push("test");

        var stackCountBeforePeek = stack.Count;
        var lastItem = stack.Pop();

        Assert.Equal("test", lastItem);
    }

    [Fact]
    public void WhenPeek_ThenTheItemIsTheLastAdded()
    {
        var stack = new Stack();
        stack.Push(1);
        stack.Push("test");

        var stackCountBeforePeek = stack.Count;
        var lastItem = stack.Peek();

        Assert.Equal("test", lastItem);
    }

}
