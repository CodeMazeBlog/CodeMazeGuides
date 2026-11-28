using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public static partial class NativeMethods
    {
        [LibraryImport("user32.dll", EntryPoint = "MessageBoxW", StringMarshalling = StringMarshalling.Utf16)]
        [SupportedOSPlatform("windows")]
        public static partial int MessageBox(IntPtr hWnd, string text, string caption, int options);
    }
}
