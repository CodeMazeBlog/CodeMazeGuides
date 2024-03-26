using System.Collections;

namespace GenericListOfAnonymousTypes;

public class GenericListOfAnonymousTypesExamples<T>
{
    public static List<T> GeneretaListOfAnonymousTypesUsingToList(T[] listItems) 
    {
         
        var listOfAnonymous = listItems.ToList();

        return listOfAnonymous;
    }

    public static ArrayList GeneretaListOfAnonymousTypesUsingArrayList(T[] listItems) 
    {
        var anonymousObj = new ArrayList { listItems };

        return anonymousObj;
    }

    public static List<T> GenerateListOfAnonymousTypesUsingCustomMethod(params T[] listItems) 
    {
        return new List<T>(listItems);
    }

    public static object[] GenerateRandomAnonymousObject() 
    {
        var anonymousObj = new[] { new { Name = "John", Age = 30 }, new { Name = "Alice", Age = 25 }, new { Name = "Bob", Age = 40 } };

        return anonymousObj;
    }
}
