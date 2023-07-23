using System.Diagnostics.CodeAnalysis;

namespace RequiredPropertiesInCSharp;

public class ClassWithRequiredPropertyAndAnnotatedCustomConstructor
{
    public required string RequiredString { get; set; }

    public ClassWithRequiredPropertyAndAnnotatedCustomConstructor() { }

    [SetsRequiredMembers]
    public ClassWithRequiredPropertyAndAnnotatedCustomConstructor(string requiredString)
    {
        RequiredString = requiredString;
    }
}