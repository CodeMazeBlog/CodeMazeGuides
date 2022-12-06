namespace ActionFuncDelegates;

public class ActionFuncExample
{
    public IEnumerable<Item> GetItemsFilteredByPrice(List<Item> data, decimal price)
    {
        var filteredData = data.Where(i => i.Price > price);

        return filteredData;
    }

    public IEnumerable<Item> GetItemsFilteredByTitle(List<Item> data, string titleContains)
    {
        var filteredData = data.Where(i => i.Title.Contains(titleContains));

        return filteredData;
    }

    public List<Item> TransformTitle(List<Item> data, string transformValue)
    {
        data.ForEach(i => i.Title = transformValue);

        return data;
    }
}