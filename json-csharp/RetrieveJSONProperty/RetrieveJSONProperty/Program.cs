using Newtonsoft.Json.Serialization;
using RetrieveJSONProperty.DTOs;
using RetrieveJSONProperty.Helper;

bool continueExecution = true;

while (continueExecution)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. ListExactPropertyNames");
    Console.WriteLine("2. ListPropertywithValue");
    Console.WriteLine("3. ResolverImplementation");
    Console.WriteLine("4. AlternateImplementation();");

    string? option = Console.ReadLine();

    switch (option)
    {
        case "1":
            ListExactPropertyNames();
            break;

        case "2":
            ListPropertyUsingSerialization();
            break;

        case "3":
            ResolverImplementation();
            break;

        case "4":
            AlternateImplementation();
            break;

        case "exit":
            continueExecution = false;
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}

static void ListExactPropertyNames()
{
    var sales = CreateSalesObject();

    Console.WriteLine("\nRetrieval using Reflection:");
    var propertyNames = JsonHelper.RetrievalUsingReflection(sales);
    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}

static void ListPropertyUsingSerialization()
{
    var sales = CreateSalesObject();

    Console.WriteLine("\nRetrieval using Serialization:");
    var propertyNames = JsonHelper.RetrievalUsingSerialization(sales);

    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}

static void ResolverImplementation()
{
    var sales = CreateSalesObject();
    
    JsonProperty salesPerYearProperty = ResolverHelper.GetJsonProperty(sales, "Slx_per_Year");
    JsonProperty salesPerDayProperty = ResolverHelper.GetJsonProperty(sales, "Slx_per_DAY");

    Console.WriteLine($"{salesPerYearProperty.PropertyName}");
    Console.WriteLine($"{salesPerDayProperty.PropertyName}");
}


static void AlternateImplementation()
{
    var sales = CreateSalesObject();

    var propertyNames = JsonTextImplementation.GetJsonPropertyNames(sales);

    Console.WriteLine("JSON property names:");
    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}

static Sales CreateSalesObject()
{
    Console.WriteLine("Enter YearlySales:");
    string? yearlySalesInput = Console.ReadLine();

    Console.WriteLine("Enter DailySales:");
    string? dailySalesInput = Console.ReadLine();

    var sales = new Sales
    {
        YearlySales = yearlySalesInput,
        DailySales = dailySalesInput
    };

    return sales;
}