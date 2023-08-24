namespace RequiredPropertiesInCSharp;

public static class Program
{
    public static void Main()
    {
        InstantiateClassWithRequiredProperty();
        InstantiateClassWithRequiredPropertyAndCustomConstructor();
        InstantiateClassWithRequiredPropertyAndAnnotatedCustomConstructor();
    }

    public static void InstantiateClassWithRequiredProperty()
    {
        // Uncommenting this line results in an error because required properties were not initialized.
        // var classWithRequiredProperty = new RewrittenClass();

        var classWithRequiredProperty = new ClassWithRequiredProperty() { RequiredString = "Hello World" };
    }

    public static void InstantiateClassWithRequiredPropertyAndCustomConstructor()
    {
        // Uncommenting this line results in an error because required properties were not initialized.
        // var classWithRequiredPropertyAndCustomConstructor = new ClassWithRequiredPropertyAndCustomConstructor("Hello World");

        var classWithRequiredPropertyAndCustomConstructor
            = new ClassWithRequiredPropertyAndCustomConstructor("Hello World") { RequiredString = "Hello World" };
    }

    public static void InstantiateClassWithRequiredPropertyAndAnnotatedCustomConstructor()
    {
        var classWithRequiredPropertyAndAnnotatedCustomConstructor
            = new ClassWithRequiredPropertyAndAnnotatedCustomConstructor("Hello World");
    }
}
