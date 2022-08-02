namespace LINQSortingAndFiltering
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                Sorting();
                Filtering();
                Console.WriteLine($"{Environment.NewLine} Run Again? (Y/N)");
                var input = Console.ReadLine() ?? "";
                run = input.ToLower().First().Equals('y') ? true : false;
            }
        }

        public static void Sorting()
        {
            var shapeList = new List<Shape>()
            {
                new Shape() { ShapeId = 0, ShapeType = "Square", ShapeHeight = 2, ShapeWidth = 2,Is3D = false },
                new Shape() { ShapeId = 1, ShapeType = "Cone", ShapeHeight = 3, ShapeWidth = 1,Is3D = true },
                new Shape() { ShapeId = 2, ShapeType = "Rectangle", ShapeHeight = 4, ShapeWidth = 6,Is3D = false }
            };

            List<Shape> sortedShapeList;

            sortedShapeList = LINQSortOrderBy(shapeList);
            PrintList(sortedShapeList);

            sortedShapeList = LINQSortOrderByDescending(shapeList);
            PrintList(sortedShapeList);

            sortedShapeList = LINQSortThenBy(shapeList);
            PrintList(sortedShapeList);

            sortedShapeList = LINQSortThenByDescending(shapeList);
            PrintList(sortedShapeList);

            var reversed = LINQSortReverse(shapeList);
            PrintList(reversed.ToList());
        }
        private static List<Shape> LINQSortOrderBy(List<Shape> shapeList)
        {
            var sortedList = shapeList.OrderBy(sl => sl.ShapeType).ToList();
            return sortedList;
        }
        private static List<Shape> LINQSortOrderByDescending(List<Shape> shapeList)
        {
            var sortedList = shapeList.OrderByDescending(sl => sl.ShapeId).ToList();
            return sortedList;
        }
        private static List<Shape> LINQSortThenBy(List<Shape> shapeList)
        {
            var sortedList = shapeList.OrderBy(sl => sl.Is3D).ThenBy(sl => sl.ShapeId).ToList();
            return sortedList;
        }

        private static List<Shape> LINQSortThenByDescending(List<Shape> shapeList)
        {
            var sortedList = shapeList.OrderByDescending(sl => sl.Is3D).ThenByDescending(sl => sl.ShapeId).ToList();
            return sortedList;
        }

        private static IEnumerable<Shape> LINQSortReverse(IEnumerable<Shape> shapeList)
        {
            var reversedList = shapeList.Reverse();

            return reversedList;
        }

        private static void PrintList(List<Shape> shapes)
        {
            Console.WriteLine("----------------------------------------");
            foreach(var shape in shapes)
            {
                Console.WriteLine($"ShapeId: {shape.ShapeId} ShapeType: {shape.ShapeType} ShapeWidth: {shape.ShapeWidth} ShapeHeight: {shape.ShapeHeight} is3D: {shape.Is3D}");
            }
            Console.WriteLine("----------------------------------------");
        }

        public static void Filtering()
        {
            var shapeList = new List<Shape>()
            {
                new Shape() { ShapeId = 0, ShapeType = "Square", ShapeHeight = 2, ShapeWidth = 2,Is3D = false },
                new Shape() { ShapeId = 1, ShapeType = "Rectangle", ShapeHeight = 4, ShapeWidth = 6,Is3D = false },
                new Shape() { ShapeId = 2, ShapeType = "Cone", ShapeHeight = 3, ShapeWidth = 1,Is3D = true },
            };

            List<Shape> filteredShapeList;

            filteredShapeList = LINQFilterWhere(shapeList);
            PrintList(filteredShapeList);

            filteredShapeList = LINQFilterWhereVerbose(shapeList);
            PrintList(filteredShapeList);

            filteredShapeList = LINQFilterOfType(shapeList);
            PrintList(filteredShapeList);

            LINQFilterExtension(shapeList);
            PrintList(shapeList);
        }

        private static List<Shape> LINQFilterWhere(List<Shape> shapeList)
        {
            var filteredList = shapeList.Where(sl => sl.ShapeHeight < 4).ToList();
            return filteredList;
        }

        private static List<Shape> LINQFilterWhereVerbose(List<Shape> shapeList)
        {
            var filteredList = shapeList.Where(sl => CheckShape(sl)).ToList();
            return filteredList;
        }

        private static bool CheckShape(Shape s)
        {
            if(s.ShapeWidth < 3 && s.Is3D)
            {
                return true;
            }
            return false;
        }
        private static List<Shape> LINQFilterOfType(List<Shape> shapeList)
        {
            var filteredList = shapeList.OfType<Shape>().ToList();
            return filteredList;
        }

        private static void LINQFilterExtension(List<Shape> shapeList)
        {
            shapeList.RemoveNullFilter();
        }
    }
}