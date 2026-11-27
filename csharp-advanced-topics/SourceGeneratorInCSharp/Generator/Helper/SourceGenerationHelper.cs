namespace Generator.Helper
{
    public static class SourceGenerationHelper
    {
        public const string Attribute = """
            namespace Generator
            {
                [System.AttributeUsage(System.AttributeTargets.Class)]
                [Microsoft.CodeAnalysis.Embedded]
                internal sealed class GenerateServiceAttribute : System.Attribute
                {
                }
            }
            """;
    }
}
