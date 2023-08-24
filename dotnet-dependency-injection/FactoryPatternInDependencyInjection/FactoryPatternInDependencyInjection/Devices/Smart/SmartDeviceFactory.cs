using FactoryPatternInDependencyInjection.LabelGen;

namespace FactoryPatternInDependencyInjection.Devices.Smart;

public class SmartDeviceFactory : IDeviceFactory
{
    private readonly LabelGenServiceFactory _labelFactory;

    public SmartDeviceFactory(LabelGenServiceFactory labelFactory)
    {
        _labelFactory = labelFactory;
    }

    public Device CreateDevice(DeviceType deviceType)
    {
        var label = _labelFactory.GetLabelGenService().Generate();

        return deviceType switch
        {
            DeviceType.Watch => new SmartWatch(label),
            DeviceType.Phone => new SmartPhone(label),
            DeviceType.Laptop => new SmartLaptop(label),
            _ => throw new NotImplementedException()
        };
    }
}