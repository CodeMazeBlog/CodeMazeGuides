namespace GenericListOfAnonymousTypes;

public class GenericListOfAnonymousTypesExamples
{
    public static List<object> GeneretaListOfAnonymousTypesUsingToList(object[] listItems) 
    {
         
        var listOfAnonymous = listItems.ToList();

        return listOfAnonymous;
    }

    public static List<dynamic> GeneretaListOfAnonymousTypesUsingDynamic(object[] listItems) 
    {
        var anonymousObj = new List<dynamic>(listItems);

        return anonymousObj;
    }

    public static List<object> GeneretaListOfAnonymousTypesUsingObject(object[] listItems)
    {
        var anonymousObj = new List<object>(listItems);

        return anonymousObj;
    }

    public static List<object> GeneretaListOfAnonymousTypesUsingLINQ()
    {
        var anonymousObj = new[] {
            new { Name = "Patrick", Age = 32 },
            new { Name = "Mary", Age = 25 },
            new { Name = "Marley", Age = 40 }
        };

        var result = anonymousObj.Select(x => new { x.Name, x.Age });

        return new List<object>(result);
    }

    public static object[] GenerateRandomAnonymousObject() 
    {
        var anonymousObj = new[] { 
            new { Name = "Patrick", Age = 32 },
            new { Name = "Mary", Age = 25 },
            new { Name = "Marley", Age = 40 } 
        };

        return anonymousObj;
    }
}