using AutoBogus;
using Bogus;
using SortingGenericList.Library;
using SortingGenericList.Library.DataModels;

const int productCount = 5;
var list = new List<Product>(productCount);

var productsList = GenerateProducts(productCount);

Console.WriteLine("----------MySortedList<Product>----------");
Console.WriteLine("**Products**");
PrintProductList(productsList);
Console.WriteLine();

var sortedCollection = new MySortedList<Product>(productsList);
Console.WriteLine("**Sorted**");
PrintProductList(sortedCollection);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

ListSortMethods.SortListInPlaceWithSort(list);
Console.WriteLine("**Sorted**");
PrintProductList(list);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort With Comparison Delegate----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

ListSortMethods.SortListInPlaceWithSort(list, (x, y) => y.CompareTo(x));
Console.WriteLine("**Sorted**");
PrintProductList(list);
Console.WriteLine();

Console.WriteLine("----------List<Product> In Place Sort With ICompare----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

ListSortMethods.SortListInPlaceWithSort(list, new DescendingProductComparer());
Console.WriteLine("**Sorted**");
PrintProductList(list);
Console.WriteLine();

Console.WriteLine("----------List<Product> Sorted With Order----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

var result = ListSortMethods.SortListWithOrder(list);
Console.WriteLine("**Sorted**");
PrintProductList(result);
Console.WriteLine();

Console.WriteLine("----------List<Product> Sorted With OrderBy ProductName----------");
Console.WriteLine("Products");
PrintProductList(productsList);

list.Clear();
list.AddRange(productsList);

result = ListSortMethods.SortListWithOrderBy(list, x => x.ProductName);
Console.WriteLine("**Sorted**");
PrintProductList(result);
Console.WriteLine();

Console.WriteLine("----------List<Product> Sorted With OrderDescending----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

result = ListSortMethods.SortListWithOrderDescending(list);
Console.WriteLine("**Sorted**");
PrintProductList(result);
Console.WriteLine();

Console.WriteLine("----------List<Product> Sorted With OrderByDescending ProductName----------");
Console.WriteLine("Products:");
PrintProductList(productsList);
Console.WriteLine();

list.Clear();
list.AddRange(productsList);

result = ListSortMethods.SortListWithOrderByDescending(list, x => x.ProductName);
Console.WriteLine("**Sorted**");
PrintProductList(result);
Console.WriteLine();

// --------------- Local Methods and Classes ---------------
static void PrintProductList(IEnumerable<Product> list)
{
    foreach (var value in list)
        Console.WriteLine($"{value.ProductName,-30}{value.Category,-20}${value.Price,-10:0.00}{value.Id,40}");
}

static Product[] GenerateProducts(int count)
{
    var faker = new AutoFaker<Product>()
                .Configure(builder =>
                    builder.WithFakerHub(new Faker {Random = new Randomizer(42)}))
                .RuleFor(p => p.ProductName, f => $"{f.Commerce.ProductAdjective()} {f.Commerce.Product()}")
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price(1, 200)))
                .RuleFor(p => p.Category, f => f.Commerce.Categories(1)[0]);

    return faker.Generate(count).ToArray();
}

internal sealed class DescendingProductComparer : IComparer<Product>
{
    public int Compare(Product? x, Product? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return -1;

        return y.CompareTo(x);
    }
}