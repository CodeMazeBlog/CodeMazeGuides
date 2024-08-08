namespace MediatorPattern.Solution;

public interface ISignal
{
    SignalName Name { get; }

    TrafficDirection Direction { get; }

    TrafficLight Light { get; }

    void ShowGreenLight();

    void ShowRedLight();
}