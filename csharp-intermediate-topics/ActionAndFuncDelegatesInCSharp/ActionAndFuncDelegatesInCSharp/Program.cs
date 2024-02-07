using ActionAndFuncDelegatesInCSharp;
using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {
        ExecuteBasicExamples();

        ExecuteAdvancedFuncExample();

        ExecuteAdvancedActionExample();
    }

    private static void ExecuteAdvancedActionExample()
    {
        //throw new NotImplementedException();
    }

    private static void ExecuteBasicExamples() { 
        var basicDelegate = new BasicDelegate();
        var inputNumber = 5;

        //Basic example delegate
        basicDelegate.Run(inputNumber);

        //Basic example action
        basicDelegate.RunAction(inputNumber);

        //Basic example func
        var result = basicDelegate.RunFunc(inputNumber);
        Console.WriteLine(result);
    }

    private static void ExecuteAdvancedFuncExample()
    {
        var exceptionHandlerService = new ExceptionHandlerService();
        var inputNumber = -5;
        try
        {
            if (inputNumber < 0)
                throw new ValidationException();
        }
        catch (Exception ex)
        {
            var errorMessage = exceptionHandlerService.GetError(ex);
            Console.WriteLine(errorMessage.GetFullError());
        }
    }

}