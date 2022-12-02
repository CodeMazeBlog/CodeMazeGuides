namespace ActionFuncDelegates;

public class Item
{
    public string Title { get; set; }
    public decimal Price { get; set; }

    public static List<Item> GetItems()
    {
        return new List<Item>()
        {
            new() {Title = "Title-1",Price = 30},
            new (){Title = "Title-2",Price = 40},
            new (){Title = "Title-3",Price = 60},
            new (){Title = "Title-4",Price = 130},
            new (){Title = "Title-5",Price = 135},
            new (){Title = "Title-6",Price = 180},
            new (){Title = "Title-7",Price = 79},
            new (){Title = "Title-8",Price = 179},
            new (){Title = "Title-9",Price = 10},
            new (){Title = "Title-10",Price = 56},
            new (){Title = "Title-11",Price = 199},
            new (){Title = "Title-12",Price = 12},
        };
    }
}