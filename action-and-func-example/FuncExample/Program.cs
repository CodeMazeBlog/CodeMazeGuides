class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 }; // Using Func delegate to find the sum of all numbers in the list
        Func<List<int>, int> findSum = (nums) =>
        {
            int sum = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                sum += nums[i];
            }
            return sum;
        };

        int total = findSum(numbers);
        Console.WriteLine("The sum of all numbers in the list is: " + total); // Using Func delegate to find the maximum number in the list

        Func<List<int>, int> findMax = (nums) =>
        {
            int max = nums[0];
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }
            }
            return max;
        };

        int maximum = findMax(numbers);
        Console.WriteLine("The maximum number in the list is: " + maximum);
    }
}
