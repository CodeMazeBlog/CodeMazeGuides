using System.Runtime.InteropServices;

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
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        var wmiQuery = "Select * from Win32_ComputerSystem";
        foreach (var item in new System.Management.ManagementObjectSearcher(wmiQuery).Get())
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
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        var coreCount = 0;
        var wmiQuery = "Select * from Win32_Processor";
        foreach (var item in new System.Management.ManagementObjectSearcher(wmiQuery).Get())
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
        if (!OperatingSystem.IsWindows())
        {
            throw new PlatformNotSupportedException();
        }

        var wmiQuery = "Select * from Win32_ComputerSystem";
        foreach (var item in new System.Management.ManagementObjectSearcher(wmiQuery).Get())
        {
            return int.Parse(item["NumberOfProcessors"].ToString());
        }
        return 0;
    }

    /// <summary>
    /// Retrieves the number of logical processors of the CPU, including also the excluded processors.
    /// </summary>
    /// <returns></returns>
    public int GetExcludedProcessors()
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
