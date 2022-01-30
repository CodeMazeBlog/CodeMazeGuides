
namespace ActionAndFuncInCSharp
{
    public class ExamplesForAction
    {
        public void ActionPointsToArgumentlessMethod()
        {
            // declaration
            Action methodAction = Method;

            // invocation
            methodAction();
        }

        public void ActionPointsToMethodWithArguments()
        {
            // declaration
            Action<int> methodWithParams = MethodWithParams;

            // invocation
            methodWithParams(10);
        }

        public void ActionPointsToLambda()
        {
            // declaration
            Action lambdaAction = () =>
            {
                Console.WriteLine("Lambda function");
            };

            // invocation
            lambdaAction();
        }

        public virtual void MethodWithParams(int paramName)
        {
            Console.WriteLine("Method with params");
        }

        public virtual void Method()
        {
            Console.WriteLine("Method without params");
        }
    }
}
