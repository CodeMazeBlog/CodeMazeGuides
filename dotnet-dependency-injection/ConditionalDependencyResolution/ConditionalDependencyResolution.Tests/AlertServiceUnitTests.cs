using ConditionalDependencyResolution.Alert;

namespace ConditionalDependencyResolution.Tests;

public class AlertServiceUnitTests : BaseUnitTest
{
    [Fact]
    public void GivenMultiVariants_WhenUsingFactoryDelegate_ThenCanBeResolvedOnDemand()
    {
        var factory = _serviceProvider.GetService<Func<AlertMode, IAlertService>>()!;

        var emailService = factory(AlertMode.Email);
        var smsService = factory(AlertMode.Sms);

        Assert.Equal("Email: Demo", emailService.Send("Demo"));
        Assert.Equal("Sms: Demo", smsService.Send("Demo"));
    }

    [Fact]
    public void GivenMultiVariants_WhenUsingFactoryClass_ThenCanBeResolvedOnDemand()
    {
        var factory = _serviceProvider.GetService<IAlertServiceFactory>()!;

        var emailService = factory.GetAlertService(AlertMode.Email);
        var smsService = factory.GetAlertService(AlertMode.Sms);

        Assert.Equal("Email: Demo", emailService.Send("Demo"));
        Assert.Equal("Sms: Demo", smsService.Send("Demo"));
    }
}