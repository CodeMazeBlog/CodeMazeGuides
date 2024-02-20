using Fluxor;

namespace FluxorInBlazor.State.Counter;

[FeatureState]
public record CounterState
{
    public int ClickCount { get; init; }
}