namespace ActionAndFuncDelegatesInCsharp.Action
{
    public class ActionDelegate
    {
        public Action<int> Action_PrintNumber = number => Console.WriteLine($"The number is {number}");

        public void Action_NamedMethod_Example(int number)
        {
            Console.WriteLine($"The number is {number}");
        }
    }
}
