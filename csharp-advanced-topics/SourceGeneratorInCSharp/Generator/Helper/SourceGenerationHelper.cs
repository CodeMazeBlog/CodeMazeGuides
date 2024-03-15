using System;
using System.Collections.Generic;
using System.Text;

namespace Generator.Helper
{
    public class SourceGenerationHelper
    {
        public const string Attribute = """
            namespace Generator
            {
                [System.AttributeUsage(System.AttributeTargets.Class)]
                public class GenerateServiceAttribute : System.Attribute
                {
                }
            }
            """;
    }
}
