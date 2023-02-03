namespace ActionPredikateandFuncExample
{
    internal class ActionDelegate
    {
        public static void Execute()
        {
            var actionDelegate = new ActionDelegate();
            actionDelegate.Show();
        }

        protected void Show()
        {
            Worker(OddNumbers, (num) => Console.WriteLine($"{num} IS divisible by 2!"));
        }

        protected void Worker(Action<int> onOddNumber, Action<int> onEvenNumber)
        {
            for (int i = 1; i < 5; i++)
            {
                if (i % 2 == 0)
                    onEvenNumber(i);
                else
                    onOddNumber(i);
            }
        }

        protected void OddNumbers(int number)
        {
            Console.WriteLine($"{number} IS NOT divisible by 2!");
        }
    }
}
