using System.Diagnostics;

namespace MetricsAPI.Services;

public static class Utilities
{
    public static double GetCpuUsagePercentage()
    {
        var process = Process.GetCurrentProcess();

        var startTime = DateTime.UtcNow;
        var initialCpuTime = process.TotalProcessorTime;

        Thread.Sleep(1000);

        var endTime = DateTime.UtcNow;
        var finalCpuTime = process.TotalProcessorTime;

        var totalCpuTimeUsed = (finalCpuTime - initialCpuTime).TotalMilliseconds;
        var totalTimeElapsed = (endTime - startTime).TotalMilliseconds;

        var cpuUsage = (totalCpuTimeUsed / (Environment.ProcessorCount * totalTimeElapsed)) * 100;

        return cpuUsage;
    }
}