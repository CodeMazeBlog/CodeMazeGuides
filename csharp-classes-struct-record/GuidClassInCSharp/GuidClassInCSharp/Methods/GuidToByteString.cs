namespace GuidClassInCSharp
{
    partial class GuidClassInCSharpMethods
    {
        public static string GuidToByteString(Guid inputGuid)
        {
            var byteArray = inputGuid.ToByteArray();

            return BitConverter.ToString(byteArray);
        }
    }
}