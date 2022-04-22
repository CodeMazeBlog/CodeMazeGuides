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
                Console.WriteLine("\n Run Again? (Y/N)");
                var input = Console.ReadLine() ?? "";
                run = input.ToLower().First().Equals('y') ? true : false;
            }
        }

        public static void Sorting()
        {
            var shapeList = new List<Shape>()
            {
                new Shape() { ShapeId = 0, ShapeType = "Square", ShapeHeight = 2, ShapeWidth = 2,Is3D = false },
                new Shape() { ShapeId = 1, ShapeType = "Rectangle", ShapeHeight = 4, ShapeWidth = 6,Is3D = false },
                new Shape() { ShapeId = 2, ShapeType = "Cone", ShapeHeight = 3, ShapeWidth = 1,Is3D = true }
            };

            List<Shape> sortedShapeList;

            sortedShapeList = LINQSortOrderBy(shapeList);
            printList(sortedShapeList);

            sortedShapeList = LINQSortOrderByDescending(shapeList);
            printList(sortedShapeList);

            sortedShapeList = LINQSortThenBy(shapeList);
            printList(sortedShapeList);

            sortedShapeList = LINQSortThenByDescending(shapeList);
            printList(sortedShapeList);

            LINQSortReverse(shapeList);
            printList(shapeList);
        }

        private static List<Shape> LINQSortOrderBy(List<Shape> shapeList)
        {
            List<Shape> sortedList = shapeList.OrderBy(sl => sl.ShapeType).ToList();
            return sortedList;
        }
        private static List<Shape> LINQSortOrderByDescending(List<Shape> shapeList)
        {
            List<Shape> sortedList = shapeList.OrderByDescending(sl => sl.ShapeId).ToList();
            return sortedList;
        }
        private static List<Shape> LINQSortThenBy(List<Shape> shapeList)
        {
            List<Shape> sortedList = shapeList.OrderBy(sl => sl.Is3D).ThenBy(sl => sl.ShapeId).ToList();
            return sortedList;
        }

        private static List<Shape> LINQSortThenByDescending(List<Shape> shapeList)
        {
            List<Shape> sortedList = shapeList.OrderByDescending(sl => sl.Is3D).ThenByDescending(sl => sl.ShapeId).ToList();
            return sortedList;
        }

        private static void LINQSortReverse(List<Shape> shapeList)
        {
            shapeList.Reverse();
        }

        private static void printList(List<Shape> shapes)
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
            printList(filteredShapeList);

            filteredShapeList = LINQFilterWhereVerbose(shapeList);
            printList(filteredShapeList);

            filteredShapeList = LINQFilterOfType(shapeList);
            printList(filteredShapeList);

            LINQFilterExtension(shapeList);
            printList(shapeList);
        }

        private static List<Shape> LINQFilterWhere(List<Shape> shapeList)
        {
            List<Shape> filteredList = shapeList.Where(sl => sl.ShapeHeight < 4).ToList();
            return filteredList;
        }

        private static List<Shape> LINQFilterWhereVerbose(List<Shape> shapeList)
        {
            List<Shape> filteredList = shapeList.Where(sl => checkShape(sl)).ToList();
            return filteredList;
        }

        private static bool checkShape(Shape s)
        {
            if(s.ShapeWidth < 3 && s.Is3D)
            {
                return true;
            }
            return false;
        }

        private static List<Shape> LINQFilterOfType(List<Shape> shapeList)
        {
            List<Shape> filteredList = shapeList.OfType<Shape>().ToList();
            return filteredList;
        }

        private static void LINQFilterExtension(List<Shape> shapeList)
        {
            shapeList.RemoveNullFilter();
        }
    }
}