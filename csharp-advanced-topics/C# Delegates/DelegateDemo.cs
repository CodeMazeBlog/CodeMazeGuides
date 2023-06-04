namespace DelegatesDemo.DelegateAppl
{
    delegate int ValueSubstitute(int n);
    public static class DelegateDemo
    {
        delegate int ValueUpdate(int n);
        static int Value = 10;
        public static int CurrentValue()
        {
            return Value;
        }
        public static int SumOperation(int p)
        {
            Value += p;
            return Value;
        }
        public static int MultOperation(int q)
        {
            Value *= q;
            return Value;
        }
        public static void RunDelegate()
        {
            ValueUpdate update1 = new ValueUpdate(SumOperation);
            ValueUpdate update2 = new ValueUpdate(MultOperation);

            update1(25);
            Console.WriteLine("Value of Num: {0}", CurrentValue());
            update2(5);
            Console.WriteLine("Value of Num: {0}", CurrentValue());
            Console.ReadKey();
        }
    }
}
