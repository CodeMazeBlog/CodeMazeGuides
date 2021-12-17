namespace Func
{
    public class FuncMethod
    {
        // Func delegate that takes one input parameter and one out parameter
        public delegate TResult Func<in T, out TResult>(T arg);
        // Func delegate that takes two input parameter and one out parameter
        public delegate TResult Func<in T,in T, out TResult>(T arg);
        // Func delegate that takes three input parameter and one out parameter
        public delegate TResult Func<in T,in T,in T, out TResult>(T arg);

        // Func can take to 16 parameters
    }
}