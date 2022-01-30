
namespace ActionAndFuncInCSharp
{
    public class ExamplesForFunc
    {
        public void FuncPointsToArgumentlessMethod()
        {
            // declaration
            Func<int> methodFunc = Method;

            // invocation
            var result = methodFunc();
        }

        public void FuncPointsToMethodWithArguments()
        {
            // declaration
            Func<int, int> methodWithParams = MethodWithParams;

            // invocation
            var result = methodWithParams(2);
        }

        public void FuncPointsToLambda()
        {
            // declaration
            Func<int> func = () =>
            {
                Console.WriteLine("Lambda function");
                return 1;
            };

            // invocation
            func();
        }

        public async Task FuncPointsToAsyncMethod()
        {
            // declaration
            Func<Task> asyncMethod = MethodAsync;

            // invocation
            await asyncMethod();
        }

        public virtual Task MethodAsync()
        {
            Console.WriteLine("Async Method");
            return Task.CompletedTask;
        }

        public virtual int Method()
        {
            Console.WriteLine("Method with params");
            return 1;
        }

        public virtual int MethodWithParams(int paramName)
        {
            Console.WriteLine("Method without params");
            return 1;
        }
    }
}
