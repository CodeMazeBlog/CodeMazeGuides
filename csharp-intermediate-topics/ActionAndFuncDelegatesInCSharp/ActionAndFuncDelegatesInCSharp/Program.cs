using ActionAndFuncDelegatesInCSharp;
using ActionAndFuncDelegatesInCSharp.AdvancedDelegates;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        ExecuteBasicExamples();

        ExecuteAdvancedFuncExample();

        ExecuteAdvancedActionExample();
    }
    private static void ExecuteBasicExamples() { 
        var basicDelegate = new BasicDelegate();
        var inputNumber = 5;

        basicDelegate.Run(inputNumber);

        basicDelegate.RunAction(inputNumber);

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

    private static void ExecuteAdvancedActionExample()
    {
        var numberChecker = new NumberChecker();
        var numbers = Enumerable.Range(1, 5).ToList();

        numbers.ForEach(num => numberChecker.Add(num));

        numberChecker.EvenNumbers.ForEach(number => Console.WriteLine($"Number {number} is even"));

        numbers = Enumerable.Range(6, 5).ToList();

        numberChecker.Add(numbers, numberChecker.isEvenNumber);

        numberChecker.EvenNumbers.ForEach(number => Console.WriteLine($"Number {number} is even"));
    }
}