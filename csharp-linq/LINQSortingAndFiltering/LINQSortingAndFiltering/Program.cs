using LINQSortingAndFiltering;

var shapeList = new List<Shape?>
{
    new Cone {ShapeId = 1, Height = 3, Width = 1},
    null,
    new Square {ShapeId = 0, Height = 2, Width = 2},
    new Rectangle {ShapeId = 2, Height = 4, Width = 6},
    null,
    new Square {ShapeId = 3, Height = 5, Width = 5}
};

Console.WriteLine("\n--------------------Sorting Examples--------------------\n");

Console.WriteLine("Order");
shapeList.Order().PrintList();

Console.WriteLine("\nOrderDescending");
shapeList.OrderDescending().PrintList();

Console.WriteLine("\nOrderBy");
shapeList.OrderBy(s => s?.ShapeType).PrintList();

Console.WriteLine("\nOrderByDescending");
shapeList.OrderByDescending(s => s?.ShapeType).PrintList();

Console.WriteLine("\nOrderBy ThenBy");
shapeList.OrderBy(s => s?.Is3D).ThenBy(s => s?.ShapeId).PrintList();

Console.WriteLine("\nOrderBy ThenByDescending");
shapeList.OrderBy(sl => sl?.Is3D).ThenByDescending(sl => sl?.ShapeId).PrintList();

Console.WriteLine("\nReverse");
shapeList.AsEnumerable().Reverse().PrintList();

Console.WriteLine("\n--------------------Filtering Examples--------------------\n");

Console.WriteLine("Where Height < 4");
shapeList.Where(s => s?.Height < 4).PrintList();

Console.WriteLine("\nFilter Is3D and Width < 3");
shapeList.Where(LinqFilteringMethods.FilterIs3DAndWidthLessThan3).PrintList();

Console.WriteLine("\nOfType<Square>");
shapeList.OfType<Square>().PrintList();

Console.WriteLine("\nFilter Is Not Null");
shapeList.FilterNotNull().PrintList();