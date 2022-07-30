namespace StaticVsNonStaticMethodsInCsharp
{
    public class StaticVsNonStaticMethods
    {
        public int Total;

        public int Addition(int a, int b)
        {
            var result = a + b;
            Console.WriteLine("Addition result: " + result);
            return result;
        }

        public static int Division(int a, int b)
        {
            var result = a / b;
            Console.WriteLine("Division result: " + result);
            return result;
        }

        public static int IncrementNumber()
        {
            var staticVsNonStatic = new StaticVsNonStaticMethods();
            for (var i = 0; i < 1000; i++)
            {  
                staticVsNonStatic.Total++;
            }

            Console.WriteLine("Result of incremented number: " + staticVsNonStatic.Total);

            return staticVsNonStatic.Total;
        }

        public List<int> NonStaticMehodForPerformanceTracking()
        {
            var count = 0;
            var elements = new List<int>();

            for (var i = 0; i < 1_000_000; i++)
            {
                if (i % 2 == 0)
                {
                    elements.Add(i);
                }
            }

            return elements;
        }

        public static List<int> StaticMehodForPerformanceTracking()
        {
            var count = 0;
            var elements = new List<int>();

            for (var i = 0; i < 1_000_000; i++)
            {
                if (i % 2 == 0)
                {
                    elements.Add(i);
                }
            }

            return elements;
        }
    }
}
