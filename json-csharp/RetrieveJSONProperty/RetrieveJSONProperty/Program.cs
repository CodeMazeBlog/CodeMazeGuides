using Newtonsoft.Json;
using RetrieveJSONProperty.DTOs;
using RetrieveJSONProperty.Helper;

bool continueExecution = true;

while (continueExecution)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. ListExactPropertyNames");
    Console.WriteLine("2. ListPropertywithValue");
    Console.WriteLine("3. PascalcaseConversion");
    Console.WriteLine("4. AlternateImplementation();");

    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            ListExactPropertyNames();
            break;

        case "2":
            ListPropertyUsingSerialization();
            break;

        case "3":
            PascalcaseConversion();
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
    Console.WriteLine("Enter YearlySales:");
    string yearlySalesInput = Console.ReadLine();

    Console.WriteLine("Enter DailySales:");
    string dailySalesInput = Console.ReadLine();

    var sales = new Sales
    {
        YearlySales = yearlySalesInput,
        DailySales = dailySalesInput
    };

    Console.WriteLine("\nRetrieval using Reflection:");
    var propertyNames = JsonHelper.RetrievalUsingReflection(sales);
    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}

static void ListPropertyUsingSerialization()
{
    Console.WriteLine("Enter YearlySales:");
    string yearlySalesInput = Console.ReadLine();

    Console.WriteLine("Enter DailySales:");
    string dailySalesInput = Console.ReadLine();

    var sales = new Sales
    {
        YearlySales = yearlySalesInput,
        DailySales = dailySalesInput
    };

    Console.WriteLine("\nRetrieval using Serialization:");
    var propertyNames = JsonHelper.RetrievalUsingSerialization(sales);

    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}

static void PascalcaseConversion()
{
    var resolver = new PascalCaseContractResolver();

    var settings = new JsonSerializerSettings
    {
        ContractResolver = resolver,
        Formatting = Formatting.Indented
    };

    Console.WriteLine("Enter ProductId:");
    string ProductId = Console.ReadLine();

    Console.WriteLine("Enter ProductName:");
    string ProductName = Console.ReadLine();

    var product = new Product
    {
        ProductId = ProductId,
        ProductName = "Widget"
    };

    var json = JsonConvert.SerializeObject(product, settings);

    Console.WriteLine(json);
}

static void AlternateImplementation()
{
    Console.WriteLine("Enter Name:");
    string Name = Console.ReadLine();

    Console.WriteLine("Enter Code:");
    string Code = Console.ReadLine();

    var country = new Country
    {
        Name = Name,
        Code = Code
    };

    var propertyNames = JsonTextImplementation.GetJsonPropertyNames(country);

    Console.WriteLine("JSON property names:");
    foreach (var propertyName in propertyNames)
    {
        Console.WriteLine(propertyName);
    }
}
