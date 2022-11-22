namespace ActionAndFuncDelegates
{
    public static class Delegates
    {
        public delegate int AddDelegate(int firstNumber, int secondNumber);
        public delegate TResult AddGenericDelegate<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    }
}