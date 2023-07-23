using FactoryPatternInDependencyInjection.LabelGen;

namespace FactoryPatternInDependencyInjection.Devices;

public class DeviceFactory : IDeviceFactory
{
    private readonly LabelGenServiceFactory _labelFactory;

    public DeviceFactory(LabelGenServiceFactory labelFactory)
    {
        _labelFactory = labelFactory;
    }

    public Device CreateDevice(DeviceType deviceType)
    {
        var label = _labelFactory.GetLabelGenService().Generate();

        return deviceType switch
        {
            DeviceType.Watch => new Watch(label),
            DeviceType.Phone => new Phone(label),
            DeviceType.Laptop => new Laptop(label),
            _ => throw new NotImplementedException()
        };
    }
}