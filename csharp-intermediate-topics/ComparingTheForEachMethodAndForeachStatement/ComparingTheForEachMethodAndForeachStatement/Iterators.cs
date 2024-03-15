namespace TheForEachMethodAndForeachStatement;

public static class Iterators
{
    public static int GetTotalOfIntListWithForEachMethod(List<int> prices)
    {
        int total = 0;

        prices.ForEach(x => total += x);

        return total;
    }

    public static int GetTotalOfIntListWithForeachStatement(List<int> prices)
    {
        int total = 0;

        foreach (var price in prices)
        {
            total += price;
        }

        return total;
    }

    public static int GetTotalOfProductsListWithForEachMethod(List<Product> products)
    {
        int total = 0;

        products.ForEach(x => total += x.Price);

        return total;
    }

    public static int GetTotalOfProductsListWithForeachStatement(List<Product> products)
    {
        int total = 0;

        foreach (var product in products)
        {
            total += product.Price;
        }

        return total;
    }
}
