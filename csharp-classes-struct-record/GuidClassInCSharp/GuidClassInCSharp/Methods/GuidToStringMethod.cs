namespace GuidClassInCSharp
{
    public partial class GuidClassInCSharpMethods
    {
        public static string GuidToString(Guid guid, string? stringFormat = "N")
        {
            return guid.ToString(stringFormat);
        }
    }
}