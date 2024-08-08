namespace MediatorPattern.Solution;

public class TrafficMediator : ITrafficMediator
{
    private readonly List<ISignal> _signals = [];

    public void Register(params ISignal[] signals)
    {
        _signals.AddRange(signals);
    }

    public void ShowGreenLight(SignalName signalName)
    {
        var signal = _signals.FirstOrDefault(x => x.Name == signalName)
            ?? throw new InvalidOperationException($"{signalName} was not registered");
                
        foreach (var crossing in _signals.Where(x => x.Direction != signal.Direction))
        {
            crossing.ShowRedLight();
        }

        foreach (var parallel in _signals.Where(x => x.Direction == signal.Direction))
        {
            parallel.ShowGreenLight();
        }
    }
}