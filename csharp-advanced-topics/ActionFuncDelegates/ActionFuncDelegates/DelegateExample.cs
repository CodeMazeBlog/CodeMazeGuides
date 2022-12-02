using static ActionFuncDelegates.DelegateExample;

namespace ActionFuncDelegates;

public class DelegateExample
{
    public delegate void MyAction<T>(T value);
    public List<Item> TransformTitle(List<Item> data, string transformValue)
    {
        // use custom MyAction<T> method 

        data.MyForeach(i => i.Title = transformValue);
        return data;

    }
}
public static class MyExtension
{
    public static IEnumerable<T> MyForeach<T>(this IEnumerable<T> items, MyAction<T> action)
    {
        foreach (var item in items)
        {
            action(item);
        }
        return items;
    }
}