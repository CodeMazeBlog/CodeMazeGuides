using RunAsyncMethodSynchronously;

namespace Tests;

public class RunAsyncMethodSynchronouslyUnitTests
{
    private readonly PersonService _personService;

    public RunAsyncMethodSynchronouslyUnitTests()
    {
        _personService = new PersonService();
    }

    [Theory]
    [InlineData(3)]
    public void WhenRunSynchronouslyMethodIsCalled_ThenReturnListOfPeople(int count)
    {
        var actual = _personService.GetPeople();

        Assert.Equal(count, actual.Count);
    }

    [Theory]
    [InlineData(3)]
    public void WhenWaitMethodIsCalled_ThenReturnListOfPeople(int count)
    {
        var actual = _personService.GetPeopleUsingWaitMethod();

        Assert.Equal(count, actual.Count);
    }

    [Theory]
    [InlineData(3)]
    public void WhenResultPropertyIsUsed_ThenReturnListOfPeople(int count)
    {
        var actual = _personService.GetPeopleUsingResultMethod();

        Assert.Equal(count, actual.Count);
    }

    [Theory]
    [InlineData(3)]
    public void WhenGetAwaiterMethodIsCalled_ThenReturnListOfPeople(int count)
    {
        var actual = _personService.GetPeopleUsingGetAwaiter();

        Assert.Equal(count, actual.Count);
    }

    [Fact]
    public void WhenWaitMethodThrowsException_ThenThrowAggregateException()
    {
        Assert.Throws<AggregateException>(() => _personService.ExceptionHandlingUsingWaitMethod());
    }

    [Fact]
    public void WhenGetAwaiterMethodThrowsException_ThenThrowException()
    {
        Assert.Throws<InvalidOperationException>(() => _personService.ExceptionHandlingUsingGetAwaiterMethod());
    }
}