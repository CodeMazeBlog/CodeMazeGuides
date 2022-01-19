
namespace ActionAndFuncInCSharp
{
    public class ExamplesForFunc
    {
        public async Task RunExamples()
        {
            // causes compilation error 
            // Func f = () => { }; 

            // declaration
            Func<int> func = () =>
            {
                Console.WriteLine("Lambda function");
                return 1;
            };
            Func<int> methodFunc = Method;
            Func<int, int> methodWithParams = MethodWithParams;
            Func<Task> asyncMethod = MethodAsync;

            // invocation
            var result1 = func();
            var result2 = methodFunc();
            var result3 = methodWithParams(2);
            await asyncMethod();
        }
        public Task MethodAsync()
        {
            Console.WriteLine("Async Method");
            return Task.CompletedTask;
        }
        public int Method()
        {
            Console.WriteLine("Method with params");
            return 1;
        }
        public int MethodWithParams(int paramName)
        {
            Console.WriteLine("Method without params");
            return 1;
        }

    }
}
