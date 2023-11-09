using StackInCSharp;
using System;
using Xunit;

namespace StackInCSharpTestProject;

public class Tests
{
    private NonGenericStackHelper _nonGenericStackHelper = new NonGenericStackHelper();
    private GenericStackHelper<Page> _genericStackHelper = new GenericStackHelper<Page>();

    [Fact]
    public void GivenNonGenerickStack_WhenPushItem_ThenStackCountIncreases()
    {
        var stack = _nonGenericStackHelper.NonGenericStack;
        var initialStackCount = _nonGenericStackHelper.GetCount();
        _nonGenericStackHelper.PushItem(1);

        Assert.Equal(initialStackCount + 1, stack.Count);
    }

    [Fact]
    public void GivenNonGenerickStack_WhenPopItem_ThenStackCountDecreases()
    {
        _nonGenericStackHelper.PushItem(1);
        _nonGenericStackHelper.PushItem("hello");

        var stackCountBeforePop = _nonGenericStackHelper.GetCount();
        _nonGenericStackHelper.PopItem();

        Assert.Equal(stackCountBeforePop - 1, _nonGenericStackHelper.GetCount());
    }

    [Fact]
    public void GivenNonGenerickStack_WhenPeekItem_ThenStackCountRemainsEqual()
    {
        _nonGenericStackHelper.PushItem(1);
        _nonGenericStackHelper.PushItem("hello");

        var stackCountBeforePeek = _nonGenericStackHelper.GetCount();
        _nonGenericStackHelper.PeekItem();

        Assert.Equal(stackCountBeforePeek, _nonGenericStackHelper.GetCount());
    }

    [Fact]
    public void GivenNonGenerickStack_WhenPop_ThenTheItemIsTheLastAdded()
    {
        _nonGenericStackHelper.PushItem(1);
        _nonGenericStackHelper.PushItem("hello");

        var lastItem = _nonGenericStackHelper.PopItem();

        Assert.Equal("hello", lastItem);
    }

    [Fact]
    public void GivenNonGenerickStack_WhenPeek_ThenTheItemIsTheLastAdded()
    {
        _nonGenericStackHelper.PushItem(1);
        _nonGenericStackHelper.PushItem("hello");

        var lastItem = _nonGenericStackHelper.PeekItem();

        Assert.Equal("hello", lastItem);
    }

    [Fact]
    public void GivenNonGenerickStack_WhenClear_ThenTheStackIsEmpty()
    {
        _nonGenericStackHelper.PushItem(1);
        _nonGenericStackHelper.PushItem("hello");

        _nonGenericStackHelper.ClearStack();

        Assert.Empty(_nonGenericStackHelper.NonGenericStack);
    }

    [Fact]
    public void GivenNonGenerickStack_WhenCreateSynchronizedStack_ThenItIsThreadSafe()
    {
        var synchronizedStack = _nonGenericStackHelper.CreateSynchonizedStack();

        Assert.False(_nonGenericStackHelper.IsSynchronizedStack(_nonGenericStackHelper.NonGenericStack));
        Assert.True(_nonGenericStackHelper.IsSynchronizedStack(synchronizedStack));
    }

    [Fact]
    public void GivenGenerickStack_WhenPushItem_ThenStackCountIncreases()
    {
        var stack = _genericStackHelper.GenericStack;
        var initialStackCount = _genericStackHelper.GetCount();
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));

        Assert.Equal(initialStackCount + 1, stack.Count);
    }

    [Fact]
    public void GivenGenerickStack_WhenPopItem_ThenStackCountDecreases()
    {
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));
        _genericStackHelper.PushItem(new Page("Another page", DateTime.Now));

        var stackCountBeforePop = _genericStackHelper.GetCount();
        _genericStackHelper.PopItem();

        Assert.Equal(stackCountBeforePop - 1, _genericStackHelper.GetCount());
    }

    [Fact]
    public void GivenGenerickStack_WhenPeekItem_ThenStackCountRemainsEqual()
    {
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));
        _genericStackHelper.PushItem(new Page("Another page", DateTime.Now));

        var stackCountBeforePeek = _genericStackHelper.GetCount();
        _genericStackHelper.PeekItem();

        Assert.Equal(stackCountBeforePeek, _genericStackHelper.GetCount());
    }

    [Fact]
    public void GivenGenerickStack_WhenPop_ThenTheItemIsTheLastAdded()
    {
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));
        _genericStackHelper.PushItem(new Page("Another page", DateTime.Now));

        var lastItem = _genericStackHelper.PopItem();

        Assert.Equal("Another page", lastItem.Title);
    }

    [Fact]
    public void GivenGenerickStack_WhenPeek_ThenTheItemIsTheLastAdded()
    {
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));
        _genericStackHelper.PushItem(new Page("Another page", DateTime.Now));

        var lastItem = _genericStackHelper.PeekItem();

        Assert.Equal("Another page", lastItem.Title);
    }

    [Fact]
    public void GivenGenerickStack_WhenClear_ThenTheStackIsEmpty()
    {
        _genericStackHelper.PushItem(new Page("New page", DateTime.Now));
        _genericStackHelper.PushItem(new Page("Another page", DateTime.Now));

        _genericStackHelper.ClearStack();

        Assert.Empty(_genericStackHelper.GenericStack);
    }
}