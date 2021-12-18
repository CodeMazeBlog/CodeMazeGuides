namespace Func
{
    public class FuncMethod
    {
        // Func delegate that takes one input parameter and one out parameter
        public delegate TResult Func<in T, out TResult>(T arg);
        // Func delegate that takes two input parameter and one out parameter
        public delegate TResult Func<in T1,in T2,out TResult>(T1 arg1, T2 arg2);
        // Func delegate that takes three input parameter and one out parameter
        public delegate TResult Func<in T1,in T2,in T3,out TResult>(T1 arg1, T2 arg2, T3 arg3);

        // Func can take to 16 parameters
    }
}