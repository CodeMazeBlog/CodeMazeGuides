namespace ActionFuncDelegates;

public partial class Delegate
{
    // Declaration
    public delegate int MyDelegate(int num1, int num2);

    public int Run()
    {
        // Initialization
        var del = Sample.Method;
        // Invocation
        var sum = del(5, 6);

        // Initialization
        del = (int num1, int num2) => num1 + num2;
        // Invocation
        sum = del(7, 8);

        return sum;
    }

    class Sample
    {
        public static int Method(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}