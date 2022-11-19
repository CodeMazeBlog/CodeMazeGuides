namespace ActionFuncInCSharp
{
    public class ActionExamples
    {
        public void CalculateAndPrint(int number1, int number2, Action<int> printAction)
        {
            int summation = number1 + number2;
            printAction(summation);
        }
        public void printTypeName(Parent parent) => Console.WriteLine(parent.Name);
        public void CovarianceCall()
        {
            Action<Child> action = printTypeName;
            action(new Child());
        }
    }
}
