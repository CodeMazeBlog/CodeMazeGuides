
namespace ActionAndFuncInCSharp
{
    public class ExamplesForAction
    {
        public void RunExamples()
        {
            // declaration
            Action lambdaAction = () =>
            {
                Console.WriteLine("Lambda function");
            };
            Action methodAction = Method;
            Action<int> methodWithParams = MethodWithParams;

            // invocation
            lambdaAction();
            methodAction();
            methodWithParams(10);
        }

        public void MethodWithParams(int paramName)
        {
            Console.WriteLine("Method with params");
        }
        public void Method()
        {
            Console.WriteLine("Method without params");
        }
    }
}
