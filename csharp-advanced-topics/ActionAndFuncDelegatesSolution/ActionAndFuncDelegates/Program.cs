namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Action delegates
            ActionDelegates actionDelegate = new();

            actionDelegate.SimpleActionDelegate();
            actionDelegate.IntDecimalActionDelegate(100, 200.65M);

            //Func delegates
            FuncDelegates funcDelegate = new();

            var result = funcDelegate.SimpleFuncDelegate();
            Console.WriteLine(result);

            var response = funcDelegate.DecimalFuncDelegate(52.25M, 65.45M);
            Console.WriteLine(response);

            //Practical Example
            StudentEligibility studentEligibility = new();
            StudentRepository.GetDistinctionStudents(studentEligibility.StudentFunc);
        }
    }
}