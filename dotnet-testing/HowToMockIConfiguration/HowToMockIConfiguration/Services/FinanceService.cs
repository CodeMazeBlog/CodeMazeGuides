using HowToMockIConfiguration.Services.Abstractions;

namespace HowToMockIConfiguration.Services;

public class FinanceService(IConfiguration configuration) : IFinanceService
{
    public double CalculateTotalAmount(double hours)
    {
        var hourlyRate = configuration.GetValue<double>("FinanceSettings:HourlyRate");

        return hourlyRate * hours;
    }
}
