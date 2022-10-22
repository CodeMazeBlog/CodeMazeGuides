namespace IndexOutOfRangeExceptionProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UtilityHelper utilityHelper = new();

            //1) Array - Upper Bound - should be less that the array length
            utilityHelper.UpperBoundMethod(false);

            //2) Array with custom lower bound
            utilityHelper.CustomLowerBoundMethod(2, false);

            //3) Incorrect Arguments
            Console.WriteLine("Please enter a search argument!!!");
            var searchArg = Convert.ToInt32(Console.ReadLine());
            utilityHelper.ListIndexOfMethod(searchArg, false);

            //4) 2 arrays with different dimensions
            utilityHelper.AssignFirstArrayElementToSecondArrayMethod(false);

            //5) Getting confused between the index and value at that index
            utilityHelper.IndexAndValueMethod(false);

            //6 -> DataTable example
            utilityHelper.DataTableMethod(false);
        }
    }
}