namespace MediatorPattern.Solution;

public interface ITrafficMediator
{
    void Register(params ISignal[] signals);

    void ShowGreenLight(SignalName signalName);
}