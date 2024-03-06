namespace RetrievalOfCpuCores;

public class CpuInformation
{
    /// <summary>
    /// Retrieves the number of logical processors of the CPU by using Environment.ProcessorCount.
    /// </summary>
    /// <returns>number of logical processors</returns>
    public int GetProcessorsCount()
    {
        return Environment.ProcessorCount;
    }

    /// <summary>
    /// Retrieves the number of logical processors of the CPU.
    /// </summary>
    /// <returns>number of logical processors</returns>
    public int GetLogicalProcessors()
    {
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
        {
            return int.Parse(item["NumberOfLogicalProcessors"].ToString());
        }
        return 0;
    }

    /// <summary>
    /// Retrieves the number of cores of the CPU.
    /// This is only supported on windows.
    /// </summary>
    /// <returns>number of cores of the CPU</returns>
    public int GetNumberOfCores()
    {
        var coreCount = 0;
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
        {
            coreCount += int.Parse(item["NumberOfCores"].ToString());
        }
        return coreCount;
    }

    /// <summary>
    /// Retrieves the number of physical processors of the CPU.
    /// This is only supported on windows.
    /// </summary>
    /// <returns>number of physical processors</returns>
    public int GetPhysicalProcessors()
    {
        foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
        {
            return int.Parse(item["NumberOfProcessors"].ToString());
        }
        return 0;
    }
}
