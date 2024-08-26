namespace MediatorPattern.Solution;

public class TrafficMediator : ITrafficMediator
{
    private Signal1? _signal1;
    private Signal2? _signal2;
    private Signal3? _signal3;
    private Signal4? _signal4;

    public void Register(Signal1 signal1, Signal2 signal2, Signal3 signal3, Signal4 signal4)
    {
        _signal1 = signal1;
        _signal2 = signal2;
        _signal3 = signal3;
        _signal4 = signal4;
    }

    public void RequestClearance(SignalName signalName)
    {
        switch (signalName)
        {
            case SignalName.Signal1:
            case SignalName.Signal3:
                _signal2?.ShowRedLight();
                _signal4?.ShowRedLight();
                break;
            case SignalName.Signal2:
            case SignalName.Signal4:
                _signal1?.ShowRedLight();
                _signal3?.ShowRedLight();
                break;
            default:
                throw new InvalidOperationException($"Unrecognized signal - {signalName}");
        }
    }
}