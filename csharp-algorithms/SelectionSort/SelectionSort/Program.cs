public class Program
{
    public static void Main(string[] args)
    {
        int[] numArray = new int[10] { 57, 1, 98, 65, 88, 24, 45, 13, 79, 34 };
        int arrayLength = numArray.Length;

        Console.Write("Unsorted array is: ");
        PrintArray(numArray, arrayLength);

        int[] sortedArray = SortArray(numArray, arrayLength);
        Console.WriteLine();
        Console.Write("Sorted array is: ");
        PrintArray(sortedArray, arrayLength);
    }

    static void PrintArray(int[] numArray, int length)
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write(numArray[i] + " ");
        }
    }

    public static int[] SortArray(int[] numArray, int arrayLength)
    {
        int tempVar, smallestVal;

        for (int i = 0; i < arrayLength - 1; i++)
        {
            smallestVal = i;

           for (int j = i + 1; j < arrayLength; j++)
            {
                if (numArray[j] < numArray[smallestVal])
                {
                    smallestVal = j;
                }
            }

            tempVar = numArray[smallestVal];
            numArray[smallestVal] = numArray[i];
            numArray[i] = tempVar;
        }
        return numArray;
    }
}

