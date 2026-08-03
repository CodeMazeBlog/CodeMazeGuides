using System.Runtime.InteropServices;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public class UnmanagedMemoryManager
    {
        public static IntPtr AllocateUnmanagedMemory(int size)
        {
            IntPtr ptr = Marshal.AllocHGlobal(size);

            return ptr;
        }

        public static void FreeUnmanagedMemory(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);
        }

        public static void WriteDataToUnmanagedMemory(IntPtr buffer, byte[] data)
        {
            for (var i = 0; i < data.Length; i++)
            {
                Marshal.WriteByte(buffer + i, data[i]);
            }
        }

        public static byte[] ReadDataFromUnmanagedMemory(IntPtr buffer, int length)
        {
            var data = new byte[length];
            for (var i = 0; i < length; i++)
            {
                data[i] = Marshal.ReadByte(buffer + i);
            }
            return data;
        }
    }
}
