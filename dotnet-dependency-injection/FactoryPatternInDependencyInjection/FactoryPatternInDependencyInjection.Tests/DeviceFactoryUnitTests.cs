using FactoryPatternInDependencyInjection.Devices;
using FactoryPatternInDependencyInjection.Devices.Smart;

namespace FactoryPatternInDependencyInjection.Tests;

public class DeviceFactoryUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenMultipleObjectTypes_WhenUsedWithFactory_ThenCanBeInstantiatedConditionally()
    {
        var factory = _serviceProvider.GetService<DeviceFactory>()!;

        Assert.IsType<Laptop>(factory.CreateDevice(DeviceType.Laptop));
        Assert.IsType<Watch>(factory.CreateDevice(DeviceType.Watch));
    }

    [Fact]
    public void GivenMultipleFactories_WhenUsedWithAbstractFactory_ThenProvideBetterAbstraction()
    {
        var masterFactory = _serviceProvider.GetService<MasterDeviceFactory>()!;

        var classic = masterFactory.GetClassicFactory();
        var smart = masterFactory.GetSmartFactory();

        Assert.IsType<Laptop>(classic.CreateDevice(DeviceType.Laptop));
        Assert.IsType<SmartLaptop>(smart.CreateDevice(DeviceType.Laptop));
    }
}