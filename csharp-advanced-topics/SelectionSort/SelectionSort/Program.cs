
public class Program
{
    public static void Main(string[] args)
    {
        //define an array of 10 integers that need to be sorted
        int[] numArray = new int[10] { 57, 1, 98, 65, 88, 24, 45, 13, 79, 34 };
        int arrayLength = numArray.Length;

        //print initial array
        Console.Write("Unsorted array is: ");
        PrintArray(numArray, arrayLength);

        //sort the array
        int[] sortedArray = SortArray(numArray, arrayLength);
        Console.WriteLine();
        Console.Write("Sorted array is: ");
        PrintArray(sortedArray, arrayLength); 
    }

    //function to print the array
    static void PrintArray(int[] numArray, int length) 
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write(numArray[i] + " ");
        }
    }

    //function to implement selection sort 
    public static int[] SortArray(int[] numArray, int arrayLength)
    {
        //set temporary and smallest variables to hold the temp and smallst elements
        int tempVar, smallestVal;

        //outer loop iterates through the array
        for (int i = 0; i < arrayLength - 1; i++)
        {

            //set the smallest value to the current element
            smallestVal = i;

            //check for the smallest value and swap it with the current smallest element
            for (int j = i + 1; j < arrayLength; j++)
            {
                if (numArray[j] < numArray[smallestVal])
                {
                    smallestVal = j;
                }
            }
            
            //swap the current element with the smallest value
            tempVar = numArray[smallestVal];
            numArray[smallestVal] = numArray[i];
            numArray[i] = tempVar;
        }
        return numArray;
    }
}

