using System;
using System.Linq;
using System.Collections.Generic;

namespace FuncAndActionDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // LINQ example
            var numbers = new int[] { 0, 1, -2, 3, -4, 5, 6 };

            var absoluteNumbers = numbers
                .Select(x => x < 0 ? -x : x)
                .ToArray();

            var signNumbers = numbers
                .Select(x => x < 0 ? -1 : x > 0 ? 1 : 0)
                .ToArray();

            var absoluteNumbersWithoutFunc = numbers
                .Select(new AbsoluteSelector())
                .ToArray();

            var signNumbersWithoutFunc = numbers
                .Select(new SignSelector())
                .ToArray();

            // Advantages over traditional delegates
            MathFunctions mathFunctions = new MathFunctions();

            UnaryDelegate absoluteDelegate = new UnaryDelegate(mathFunctions.AbsoluteFunction);

            UnaryDelegate signDelegate = new UnaryDelegate(mathFunctions.SignFunction);

            // Func delegates

            Func<int, int> absoluteFuncDelegate = delegate (int x)
            {
                return x < 0 ? -x : x;
            };

            Func<int, int> signFuncDelegate = delegate (int x)
            {
                return x < 0 ? -1 : x > 0 ? 1 : 0;
            };


            // Multicast example
            Action<string> logger = (message) => { 
                var log = $"Message from first logger: {message}"; 
                // Send log somewhere
            };

            logger += (message) => { 
                var log = $"Message from second logger: {message}";
                // Send log somewhere
            }; 

            Example.Log(logger, "Please log me!");

            // Covariance and contravariance example
            Func<object> returnHelloWorldMessage = () => "Hello world!";

            Action<object> contravarianceExample = (x) => {
                var exampleVariable = x;
            };

            Action<string> x = contravarianceExample;
        }
    }

    /// <summary>
    /// LINQ interface example 
    /// </summary>
    public interface Linq<TResult, TSource>
    {
        TResult Selector(TSource source);
    }

    /// <summary>
    /// Helper class for the Log and Select method used in main
    /// </summary>
    public static class Example
    { 
        public static void Log(Action<string> logger, string message)
        {
            logger(message);            
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Linq<TResult, TSource> selector)
        {
            foreach(var item in source)
            {
                yield return selector.Selector(item);
            }
        }
    }

    /// <summary>
    /// Example of the Linq implementation. Math absolute method is used as an inspiration.
    /// </summary>
    public class AbsoluteSelector: Linq<int, int>
    {
        public int Selector(int item)
        {
            return item < 0 ? -item : item;
        }
    }

    /// <summary>
    /// Example of the Linq implementation. Math sign method is used as an inspiration.
    /// </summary>
    public class SignSelector: Linq<int, int>
    {
        public int Selector(int item)
        {
            return item < 0 ? -1 : item > 0 ? 1 : 0;
        }
    }

    /// <summary>
    /// Explicitly defined delegate
    /// </summary>
    public delegate int UnaryDelegate(int x);

    /// <summary>
    /// Implementations for the delegates
    /// </summary>
    public class MathFunctions
    {
        public int AbsoluteFunction(int x)
        {
            return x < 0 ? -x : x;
        }

        public int SignFunction(int x)
        {
            return x < 0 ? -1 : x > 0 ? 1 : 0;
        }
    }
}
