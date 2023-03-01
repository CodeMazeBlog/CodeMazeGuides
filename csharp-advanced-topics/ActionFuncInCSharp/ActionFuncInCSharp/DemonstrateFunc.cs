namespace ActionFuncInCSharp
{
    public class DemonstrateFunc
    {
        public int Sum(int[] array)
        {
            return array.Sum();
        }

        public int Product(int[] array)
        {
            return array.Aggregate((p1, p2) => p1 * p2);
        }

        public void Main(int[] array)
        {
            Console.WriteLine("Demonstrating Func<>");

            //int[] parameters = { 5, 5, 5 };
            Console.WriteLine($"Input parameters are {string.Join(",", array)}");
            Console.WriteLine();
            Common(Sum, array);
            Common(Product, array);
            Console.WriteLine();
            Console.WriteLine("Anonymous method example:");
            Func<int[], int> func = delegate (int[] parameters) { return Sum(parameters); };
            Console.WriteLine($"The sum is {func(array)}");
            Console.WriteLine();
            Console.WriteLine("Lambda expression example:");
            Func<int[], int> lambda = p => Product(p);
            Console.WriteLine($"The product is {lambda(array)}");
        }

        void Common(Func<int[], int> funcType, int[] array)
        {
            int result = funcType(array);
            Console.WriteLine($"The result is {result}");
        }
    }
}
