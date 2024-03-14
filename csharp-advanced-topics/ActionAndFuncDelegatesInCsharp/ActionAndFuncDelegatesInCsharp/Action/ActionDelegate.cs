namespace ActionAndFuncDelegatesInCsharp.Action
{
    public class ActionDelegate
    {
        public Action<int> PrintNumber = number => Console.WriteLine($"The number is {number}");

        public void PrintNumberNamedMethod(int number)
        {
            Console.WriteLine($"The number is {number}");
        }
    }
}
