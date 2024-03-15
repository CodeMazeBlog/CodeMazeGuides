using System.Runtime.InteropServices;
using System.Text;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);

        static void Main(string[] args)
        {
            //Unmanaged Code

            MessageBox(IntPtr.Zero, "Hello, World!", "Message", 0);

            var numbers = new int[] { 1, 2, 3, 4, 5 };

            unsafe
            {
                fixed (int* ptr = numbers)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        Console.WriteLine(*(ptr + i));
                    }
                }
            }

            var bufferSize = 1024;
            IntPtr buffer = UnmanagedMemoryManager.AllocateUnmanagedMemory(bufferSize);

            var dataToWrite = new byte[] { 1, 2, 3, 4 };
            UnmanagedMemoryManager.WriteDataToUnmanagedMemory(buffer, dataToWrite);

            var readData = UnmanagedMemoryManager.ReadDataFromUnmanagedMemory(buffer, dataToWrite.Length);

            Console.WriteLine("Data read from unmanaged memory:");
            foreach (byte value in readData)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            UnmanagedMemoryManager.FreeUnmanagedMemory(buffer);

            // Marshaling a string from managed to unmanaged code
            var input = "Purple Jackets";
            IntPtr unmanagedString = Marshal.StringToHGlobalAnsi(input);

            Marshal.FreeHGlobal(unmanagedString);

            //Managed Code

            var memoryManager = new ManagedMemoryManager();

            var memoryBeforeAllocation = GC.GetTotalMemory(false);
            memoryManager.AllocateMemory();
            var memoryAfterAllocation = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory Allocated to the list: {memoryAfterAllocation - memoryBeforeAllocation} bytes");

            //Showcasing Best Practices

            // Bad practice: creating unnecessary objects
            var memoryBeforeConcat = GC.GetTotalMemory(false);
            var str = string.Empty;

            for (var i = 0; i < 100000; i++)
            {
                str += i.ToString();
            }

            var memoryAfterConcat = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory used by string concatenation: {memoryAfterConcat - memoryBeforeConcat} bytes");


            // Good practice: avoiding unnecessary objects
            var memoryBeforeStringBuilder = GC.GetTotalMemory(false);
            var sb = new StringBuilder();

            for (var i = 0; i < 100000; i++)
            {
                sb.Append(i);
            }

            var result = sb.ToString();
            var memoryAfterStringBuilder = GC.GetTotalMemory(false);

            Console.WriteLine($"Memory used by StringBuilder: {memoryAfterStringBuilder - memoryBeforeStringBuilder} bytes");
        }
    }
}