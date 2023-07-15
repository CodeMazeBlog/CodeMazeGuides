namespace GuidClassInCSharp
{
    partial class GuidClassInCSharpMethods
    {
        public static string GuidToByteStringStackAllocation(Guid inputGuid)
        {
            Span<byte> dest = stackalloc byte[16];
            inputGuid.TryWriteBytes(dest);

            return BitConverter.ToString(dest.ToArray());
        }
    }
}