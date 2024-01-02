using ActionAndFuncDelegatesInCSharp;

public static class Program
{
    public static void Main(string[] args)
    {
        ActionExamples.MethodReferenceExample("Sample value");
        ActionExamples.AnonymousMethodExample("CodeMaze");
        ActionExamples.LambdaExpressionExample(13);
        
        FunctionExamples.MethodReferenceExample(3.3, 3);
        FunctionExamples.AnonymousMethodExample();
        FunctionExamples.LambdaExpressionExample();
    }
}