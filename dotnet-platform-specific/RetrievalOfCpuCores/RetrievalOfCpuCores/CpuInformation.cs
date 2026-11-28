using System.Management;
using System.Runtime.InteropServices;

namespace RetrievalOfCpuCores;

public class CpuInformation
{
    const string wmiQuery = "Select * from Win32_ComputerSystem";

    /// <summary>
    /// Retrieves the number of processors available to the current process by using Environment.ProcessorCount.
    /// </summary>
    /// <returns>number of processors available to the process</returns>
    public int GetProcessorsCount()
    {
        return Environment.ProcessorCount;
    }

    /// <summary>
    /// Retrieves the number of logical processors of the machine.
    /// This is only supported on Windows.
    /// </summary>
    /// <returns>number of logical processors</returns>
    public int GetLogicalProcessors()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        using var searcher = new ManagementObjectSearcher(wmiQuery);
        foreach (var item in searcher.Get())
        {
            return Convert.ToInt32(item["NumberOfLogicalProcessors"]);
        }

        return 0;
    }

    /// <summary>
    /// Retrieves the number of cores of the CPU.
    /// This is only supported on Windows.
    /// </summary>
    /// <returns>number of cores of the CPU</returns>
    public int GetNumberOfCores()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        var coreCount = 0;
        using var searcher = new ManagementObjectSearcher("Select * from Win32_Processor");
        foreach (var item in searcher.Get())
        {
            coreCount += Convert.ToInt32(item["NumberOfCores"]);
        }

        return coreCount;
    }

    /// <summary>
    /// Retrieves the number of physical processors of the CPU.
    /// This is only supported on Windows.
    /// </summary>
    /// <returns>number of physical processors</returns>
    public int GetPhysicalProcessors()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        using var searcher = new ManagementObjectSearcher(wmiQuery);
        foreach (var item in searcher.Get())
        {
            return Convert.ToInt32(item["NumberOfProcessors"]);
        }

        return 0;
    }

    /// <summary>
    /// Retrieves the number of logical processors of the CPU, including the excluded processors.
    /// This is only supported on Windows.
    /// </summary>
    /// <returns>number of logical processors, including the excluded ones</returns>
    public int GetLogicalProcessorsIncludingExcluded()
    {
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        var deviceCount = 0;
        var deviceList = IntPtr.Zero;
        var processorGuid = new Guid("{50127dc3-0f36-415e-a6cc-4cb3be910b65}");

        try
        {
            deviceList = SetupDiGetClassDevs(ref processorGuid, "ACPI", IntPtr.Zero, (int)DIGCF.PRESENT);
            for (var deviceNumber = 0; ; deviceNumber++)
            {
                var deviceInfo = new SP_DEVINFO_DATA();
                deviceInfo.cbSize = Marshal.SizeOf(deviceInfo);

                if (!SetupDiEnumDeviceInfo(deviceList, deviceNumber, ref deviceInfo))
                {
                    deviceCount = deviceNumber;
                    break;
                }
            }
        }
        finally
        {
            if (deviceList != IntPtr.Zero) { SetupDiDestroyDeviceInfoList(deviceList); }
        }

        return deviceCount;
    }

    /// <summary>
    /// Retrieves the number of logical processors that are excluded from Windows.
    /// This is only supported on Windows.
    /// </summary>
    /// <returns>number of excluded processors</returns>
    public int GetExcludedProcessors()
    {
        return GetLogicalProcessorsIncludingExcluded() - GetLogicalProcessors();
    }

    [DllImport("setupapi.dll", SetLastError = true)]
    private static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid,
        [MarshalAs(UnmanagedType.LPStr)] string enumerator,
        IntPtr hwndParent,
        int Flags);

    [DllImport("setupapi.dll", SetLastError = true)]
    private static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

    [DllImport("setupapi.dll", SetLastError = true)]
    private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet,
        int MemberIndex,
        ref SP_DEVINFO_DATA DeviceInterfaceData);

    [StructLayout(LayoutKind.Sequential)]
    private struct SP_DEVINFO_DATA
    {
        public int cbSize;
        public Guid ClassGuid;
        public uint DevInst;
        public IntPtr Reserved;
    }

    private enum DIGCF
    {
        DEFAULT = 0x1,
        PRESENT = 0x2,
        ALLCLASSES = 0x4,
        PROFILE = 0x8,
        DEVICEINTERFACE = 0x10,
    }
}
