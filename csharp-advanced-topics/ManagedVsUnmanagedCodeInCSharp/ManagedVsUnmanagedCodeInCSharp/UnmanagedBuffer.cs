using System.Runtime.InteropServices;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public sealed class UnmanagedBuffer : SafeHandle
    {
        public UnmanagedBuffer(int size) : base(IntPtr.Zero, ownsHandle: true)
        {
            SetHandle(Marshal.AllocHGlobal(size));
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Marshal.FreeHGlobal(handle);

            return true;
        }
    }
}
