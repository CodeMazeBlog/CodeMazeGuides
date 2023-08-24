namespace FactoryPatternInDependencyInjection.Recorder;

public class RecorderServiceFactory
{
    public RecorderService CreateRecorderService()
    {
        var service = new RecorderService();
        service.Initialize();

        return service;
    }
}