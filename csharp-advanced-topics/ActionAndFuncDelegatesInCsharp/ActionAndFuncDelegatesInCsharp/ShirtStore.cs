namespace ActionAndFuncDelegatesInCsharp;

public class ShirtStore
{
    public List<Shirt> AvailableShirts = new List<Shirt>()
    {
        new Shirt("L", "Nike"),
        new Shirt("S", "Nike"),
        new Shirt("L", "Reebok"),
        new Shirt("XS", "Reebok"),
        new Shirt("L", "CodeMaze Shirt")
    };

    public IEnumerable<Shirt> GetShirtsThatFit(string wantedshirtsize)
    {
        foreach (var availableshirt in AvailableShirts)
        {
            if (availableshirt.Size == wantedshirtsize)
            {
                yield return availableshirt;
            }
        }
    }

    public IEnumerable<Shirt> GetShirtsThatFit(Func<Shirt, bool> ShirtPropertyComparer)
    {
        foreach (var shirt in AvailableShirts)
        {
            if (ShirtPropertyComparer(shirt))
                yield return shirt;
        }
    }

    public void BuyShirt(Shirt shirt, Action<Shirt> buyShirtCallback)
    {
        AvailableShirts.Remove(shirt);
        buyShirtCallback(shirt);
    }
}
