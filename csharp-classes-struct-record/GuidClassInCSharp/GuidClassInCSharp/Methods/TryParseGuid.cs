namespace GuidClassInCSharp
{
    partial class GuidClassInCSharpMethods
    {
        public static Guid TryParseGuid(string inputStringGuid)
        {
            if(Guid.TryParse(inputStringGuid, out Guid outputGuid))
            {
                return outputGuid;
            }
            else
            {
                return Guid.Empty;
            }
        }
    }
}