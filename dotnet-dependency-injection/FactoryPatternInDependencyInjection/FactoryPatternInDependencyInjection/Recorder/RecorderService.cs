namespace FactoryPatternInDependencyInjection.Recorder;

public class RecorderService
{
    private bool _isDeviceReady = false;

    public void Initialize()
    {
        // Initialization of hardware connection goes here
        _isDeviceReady = true;
    }

    public string Record(string message)
    {
        if (!_isDeviceReady)
            throw new InvalidOperationException("Device is not ready");

        return $"Recorded: {message}";
    }
}