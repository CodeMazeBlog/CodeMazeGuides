namespace GuidClassInCSharp
{
    partial class GuidClassInCSharpMethods
    {
        public static Guid GuidFromByteArray(byte[] inputByteArray)
        {
            return new Guid(inputByteArray);
        }
    }
}