namespace FactoryPatternInDependencyInjection.Devices;

public interface IDeviceFactory
{
    Device CreateDevice(DeviceType deviceType);
}