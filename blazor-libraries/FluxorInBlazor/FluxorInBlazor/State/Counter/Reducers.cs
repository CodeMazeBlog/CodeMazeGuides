using Fluxor;
using FluxorInBlazor.State.Counter.Actions;

namespace FluxorInBlazor.State.Counter;

public static class Reducers
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) => new() { ClickCount = state.ClickCount + 1 };
}