namespace ActionFuncInCSharp
{
    public class DemonstrateAction
    {
        private void PrintSum(int[] array)
        {
            int sum = array.Sum();
            Console.WriteLine($"The sum is {sum}");
        }

        private void PrintProduct(int[] array)
        {
            int product = array.Aggregate((p1, p2) => p1 * p2);
            Console.WriteLine($"The product is {product}");
        }

        public void Main(int[] array)
        {
            Console.WriteLine("Demonstrating Action<>");
            //int[] array = { 5, 5, 5 };
            Console.WriteLine($"Input parameters are {string.Join(",", array)}");
            Console.WriteLine();
            Common(PrintSum, array);
            Common(PrintProduct, array);
            Console.WriteLine();
            Console.WriteLine("Anonymous method example:");
            Action<int[]> anonymous = delegate (int[] parameters) { PrintSum(parameters); };
            anonymous(array);
            Console.WriteLine();
            Console.WriteLine("Lambda expression example:");
            Action<int[]> lambda = p => PrintProduct(array);
            lambda(array);
        }

        void Common(Action<int[]> actionType, int[] array)
        {
            actionType(array);
        }
    }
}
