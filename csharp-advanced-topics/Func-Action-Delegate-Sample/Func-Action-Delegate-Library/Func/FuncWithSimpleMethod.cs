namespace Func_Action_Delegate_Library.Func
{
    public class FuncWithSimpleMethod
    {
        public string Sum(int a, int b)
        {
            return (a + b).ToString();
        }

        public Func<int, int, string> calculateSum;
    }
}