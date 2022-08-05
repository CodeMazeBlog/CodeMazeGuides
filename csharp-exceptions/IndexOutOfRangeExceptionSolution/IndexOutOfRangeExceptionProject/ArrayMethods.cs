namespace IndexOutOfRangeExceptionProject
{
    public class ArrayMethods
    {
        public static void UpperBoundMethod()
        {
            var numbersArray = new int[] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < numbersArray.Length; i++)
            {
                Console.WriteLine(numbersArray[i]);
            }
        }
    }
}