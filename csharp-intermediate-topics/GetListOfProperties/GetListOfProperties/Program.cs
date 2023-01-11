using GetListOfProperties;
using GetListOfProperties.Entity;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        var propertiesRetriever = new PropertiesRetriever();
        PropertyInfo[] properties;

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Get the List of Properties From a Class in C# ");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine();

        Console.WriteLine("Default call (No BindingFlag) on the Person class:");
        properties = propertiesRetriever.RetrieveProperties(new Person());
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Default call (No BindingFlag) on the User class:");
        properties = propertiesRetriever.RetrieveProperties(new User());
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Instance and Public filters:");
        properties = propertiesRetriever.RetrievePropertiesWithFilter(new User(),
            BindingFlags.Instance |
            BindingFlags.Public);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Instance and Static public filters:");
        properties = propertiesRetriever.RetrievePropertiesWithFilter(new Configuration(),
            BindingFlags.Instance |
            BindingFlags.Static |
            BindingFlags.Public);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Static public filters:");
        properties = propertiesRetriever.RetrievePropertiesWithFilter(new Configuration(),
            BindingFlags.Static |
            BindingFlags.Public);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Instance, Public and NonPublic filters:");
        properties = propertiesRetriever.RetrievePropertiesWithFilter(new User(),
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Instance, Public and NonPublic from the children class:");
        properties = propertiesRetriever.RetrievePropertiesWithFilter(new User(),
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine("Only Parent Members");
        properties = propertiesRetriever.RetrieveParentClassPropertiesWithFilter(new User(),
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic);
        propertiesRetriever.PrintProperties(properties);

        Console.WriteLine();
        Console.WriteLine("Press <ENTER> to finish");
        Console.ReadLine();
    }
}

