namespace GuidClassInCSharp
{
    public partial class GuidClassInCSharpMethods
    {
        public static Guid CreateSpecificGuid (string guid)
        {
            return new Guid(guid);
        }
    }
}