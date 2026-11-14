using System.Text.Json;

namespace RequiredPropertiesInCSharp;

public static class Program
{
    public static void Main()
    {
        InstantiateClassWithRequiredProperty();
        InstantiateClassWithRequiredPropertyAndCustomConstructor();
        InstantiateClassWithRequiredPropertyAndAnnotatedCustomConstructor();
        InstantiateRecordWithRequiredInitProperty();
        InstantiateOrderWithForgetfulConstructor();
        DeserializeCustomerWithMissingName();
        DeserializeCustomerWithNullName();
    }

    public static void InstantiateClassWithRequiredProperty()
    {
        // Uncommenting this line results in error CS9035 because the required property is not initialized.
        // var classWithRequiredProperty = new ClassWithRequiredProperty();

        var classWithRequiredProperty = new ClassWithRequiredProperty() { RequiredString = "Hello World" };
    }

    public static void InstantiateClassWithRequiredPropertyAndCustomConstructor()
    {
        // Uncommenting this line results in error CS9035 because the required property is not initialized.
        // var classWithRequiredPropertyAndCustomConstructor = new ClassWithRequiredPropertyAndCustomConstructor("Hello World");

        var classWithRequiredPropertyAndCustomConstructor
            = new ClassWithRequiredPropertyAndCustomConstructor("Hello World") { RequiredString = "Hello World" };
    }

    public static void InstantiateClassWithRequiredPropertyAndAnnotatedCustomConstructor()
    {
        var classWithRequiredPropertyAndAnnotatedCustomConstructor
            = new ClassWithRequiredPropertyAndAnnotatedCustomConstructor("Hello World");
    }

    public static void InstantiateRecordWithRequiredInitProperty()
    {
        var product = new Product { Sku = "A-1" };

        Console.WriteLine(product);
    }

    public static void InstantiateOrderWithForgetfulConstructor()
    {
        var order = new Order();

        Console.WriteLine($"Customer is null: {order.Customer is null}, Quantity: {order.Quantity}");
    }

    public static void DeserializeCustomerWithMissingName()
    {
        try
        {
            JsonSerializer.Deserialize<Customer>("""{"Email":"ana@example.com"}""");
        }
        catch (JsonException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void DeserializeCustomerWithNullName()
    {
        var customer = JsonSerializer.Deserialize<Customer>("""{"Name":null}""");
        Console.WriteLine($"Name is null: {customer!.Name is null}");

        var options = new JsonSerializerOptions { RespectNullableAnnotations = true };
        try
        {
            JsonSerializer.Deserialize<Customer>("""{"Name":null}""", options);
        }
        catch (JsonException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // Uncommenting this method results in error CS9040 because ClassWithRequiredProperty has required members.
    // public static ClassWithRequiredProperty CreateWithNewConstraint() => Create<ClassWithRequiredProperty>();

    public static T Create<T>() where T : new() => new T();
}
