namespace ActionFuncDelegates;

public class ActionFuncExample
{
    public IEnumerable<Item> GetItemsFilteredByPrice(List<Item> data, decimal price)
    {
        // Use of build-in Func delegate as lambda expression.

        var filteredData = data.Where(i => i.Price > price);
        return filteredData;
    }

    public IEnumerable<Item> GetItemsFilteredByTitle(List<Item> data, string titleContains)
    {
        // Use of build-in Func delegate as lambda expression to pass a different condition.

        var filteredData = data.Where(i => i.Title.Contains(titleContains));
        return filteredData;

    }

    public List<Item> TransformTitle(List<Item> data, string transformValue)
    {
        // Use of build-in Action delegate 
        data.ForEach(i => i.Title = transformValue);
        return data;


    }
}