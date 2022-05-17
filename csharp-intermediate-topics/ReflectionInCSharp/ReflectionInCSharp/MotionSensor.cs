using System.ComponentModel;

namespace ReflectionInCSharp;

[Description("Detects movements in the vicinity")]
public class MotionSensor : IMotionSensor
{
    private int _detections;

    public string? FocalPoint;

    public MotionSensor() : this("*") { }

    public MotionSensor(string focalPoint) => FocalPoint = focalPoint;

    public event EventHandler<string>? MotionDetected;

    [Description("Turn On/Off")]
    public bool Enabled { get; set; }

    public string Status => _detections > 0 ? "Red" : "Green";

    public void Observe() => RaiseMotionDetected("*");

    public void Observe(string direction) => RaiseMotionDetected(direction);

    public bool IsCritical(int threshold) => _detections >= threshold;

    private void RaiseMotionDetected(string direction)
    {
        _detections++;
        FocalPoint = direction;
        MotionDetected?.Invoke(this, direction);
    }
}