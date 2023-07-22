namespace Action_Func
{
    public static class ActionExample
    {
        public static Action<int, int> Calculate = (firstNum, secondNum) =>
        {
            Console.WriteLine($"Sum of the {firstNum} and {secondNum} is: {firstNum + secondNum}");
            Console.WriteLine($"Subtract of the {firstNum} from {secondNum} is: {firstNum - secondNum}");
            Console.WriteLine($"Product of the {firstNum} and {secondNum} is: {firstNum * secondNum}");
            Console.WriteLine($"Division of the {firstNum} and {secondNum} is {firstNum / secondNum}");
        };
    }
}
