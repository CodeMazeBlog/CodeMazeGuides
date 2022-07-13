namespace ActionAndFuncDelegates
{
    public class ActionDelegates
    {
        public decimal Sum { get; set; }
        public Action SimpleActionDelegate { get; set; }
        public Action<int, decimal> IntDecimalActionDelegate { get; set; }
        public ActionDelegates()
        {
            SimpleActionDelegate = () => Console.WriteLine("The simplest action delegate");
            IntDecimalActionDelegate = (int num1, decimal num2) =>
            {
                Sum = num1 + num2;
                Console.WriteLine($"The sum is {Sum}");
            };
        }
    }
}
