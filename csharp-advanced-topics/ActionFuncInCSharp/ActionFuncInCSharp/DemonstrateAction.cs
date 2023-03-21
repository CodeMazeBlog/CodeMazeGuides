namespace ActionFuncInCSharp
{
    public class DemonstrateAction
    {
        public int Sum { get; private set; }
        public int Product { get; private set; }
        public void PrintSum(int[] array)
        {
            Sum = array.Sum();
            Console.WriteLine($"The sum is {Sum}");
        }

        public void PrintProduct(int[] array)
        {
            Product = array.Aggregate((p1, p2) => p1 * p2);
            Console.WriteLine($"The product is {Product}");
        }

        public void Main(int[] array)
        {
            Console.WriteLine("Demonstrating Action<>");

            Console.WriteLine($"Input parameters are {string.Join(",", array)}");
            
            Common(PrintSum, array);
            Common(PrintProduct, array);
            
            Console.WriteLine("Anonymous method example:");
            Action<int[]> anonymous = delegate (int[] parameters) { PrintSum(parameters); };
            anonymous(array);
            
            Console.WriteLine("Lambda expression example:");
            Action<int[]> lambda = p => PrintProduct(array);
            lambda(array);
        }

        public void Common(Action<int[]> actionType, int[] array)
        {
            actionType(array);
        }
    }
}
