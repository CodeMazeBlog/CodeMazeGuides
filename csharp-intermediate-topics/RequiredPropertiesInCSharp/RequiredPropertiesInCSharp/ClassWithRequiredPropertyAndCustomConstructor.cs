namespace RequiredPropertiesInCSharp;

public class ClassWithRequiredPropertyAndCustomConstructor
{
    public required string RequiredString { get; set; }

    public ClassWithRequiredPropertyAndCustomConstructor() { }

    public ClassWithRequiredPropertyAndCustomConstructor(string requiredString)
    {
        RequiredString = requiredString;
    }
}
