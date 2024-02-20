using FluxorInBlazor.State.Counter;

namespace FluxorInBlazor.Tests;

public class CounterReducerUnitTest
{
    [Test]
    public void GivenOldCounterState_WhenHasZeroClick_ThenShouldCreateNewStateWithOneClickAndNotModifyTheOldState()
    {
        const int initialClickCount = 0;
        var oldState = new CounterState { ClickCount = initialClickCount };
        
        var newState = Reducers.ReduceIncrementCounterAction(oldState, new());
        
        Assert.That(newState.ClickCount, Is.EqualTo(initialClickCount + 1));
        Assert.That(oldState.ClickCount, Is.EqualTo(initialClickCount));
    }
}