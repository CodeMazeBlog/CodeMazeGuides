using System.Runtime.InteropServices;
using ManagedVsUnmanagedCodeInCSharp;

// Unmanaged code

if (OperatingSystem.IsWindows())
{
    NativeMethods.MessageBox(IntPtr.Zero, "Hello, World!", "Message", 0);
}

var numbers = new int[] { 1, 2, 3, 4, 5 };

unsafe
{
    fixed (int* ptr = numbers)
    {
        for (var i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(*(ptr + i));
        }
    }
}

var bufferSize = 1024;
IntPtr buffer = UnmanagedMemoryManager.AllocateUnmanagedMemory(bufferSize);

try
{
    var dataToWrite = new byte[] { 1, 2, 3, 4 };
    UnmanagedMemoryManager.WriteDataToUnmanagedMemory(buffer, dataToWrite);

    var readData = UnmanagedMemoryManager.ReadDataFromUnmanagedMemory(buffer, dataToWrite.Length);

    Console.WriteLine("Data read from unmanaged memory:");
    Console.WriteLine(string.Join(" ", readData));
}
finally
{
    UnmanagedMemoryManager.FreeUnmanagedMemory(buffer);
}

using (var unmanagedBuffer = new UnmanagedBuffer(bufferSize))
{
    Marshal.WriteByte(unmanagedBuffer.DangerousGetHandle(), 42);
    Console.WriteLine($"First byte of the SafeHandle buffer: {Marshal.ReadByte(unmanagedBuffer.DangerousGetHandle())}");
}

// Marshaling a string from managed to unmanaged code
var input = "Purple Jackets";
IntPtr unmanagedString = Marshal.StringToHGlobalAnsi(input);

try
{
    Console.WriteLine(Marshal.PtrToStringAnsi(unmanagedString));
}
finally
{
    Marshal.FreeHGlobal(unmanagedString);
}

Console.WriteLine($"Size of ToyCarInfo in unmanaged memory: {Marshal.SizeOf<ToyCarInfo>()} bytes");

// Managed code

var memoryManager = new ManagedMemoryManager();

var memoryBeforeAllocation = GC.GetTotalMemory(false);
memoryManager.AllocateMemory();
var memoryAfterAllocation = GC.GetTotalMemory(false);

Console.WriteLine($"Memory Allocated to the list: {memoryAfterAllocation - memoryBeforeAllocation} bytes");

Console.WriteLine($"1,000-byte array is in generation {GenerationInspector.GetArrayGeneration(1_000)}");
Console.WriteLine($"100,000-byte array is in generation {GenerationInspector.GetArrayGeneration(100_000)}");

// Showcasing best practices

Console.WriteLine($"Memory allocated by string concatenation: {StringBuildingAllocations.MeasureConcatenation(10_000)} bytes");
Console.WriteLine($"Memory allocated by StringBuilder: {StringBuildingAllocations.MeasureStringBuilder(10_000)} bytes");
