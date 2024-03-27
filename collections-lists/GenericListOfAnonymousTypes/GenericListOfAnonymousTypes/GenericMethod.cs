namespace GenericListOfAnonymousTypes;

public class GenericMethod<T>
{
    public static List<T> CreateGenericList<T>(T[] listItems) 
    { 
        return new List<T>(listItems); 
    }
}
