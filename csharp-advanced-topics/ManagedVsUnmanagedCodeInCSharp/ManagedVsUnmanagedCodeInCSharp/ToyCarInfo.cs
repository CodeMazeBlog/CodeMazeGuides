using System.Runtime.InteropServices;

namespace ManagedVsUnmanagedCodeInCSharp
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ToyCarInfo
    {
        public byte Color;
        public int ModelNumber;
        public float Weight;
    }
}
