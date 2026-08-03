using System.Runtime.InteropServices;

namespace ManagedVsUnmanagedCodeInCSharp
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct ToyCarInfo
    {
        public byte Color;
        public int ModelNumber;
        public float Weight;
    }
}
