using Microsoft.AspNetCore.Mvc;
using ActionAndFunctionDelegates.Helpers;
using System.Reflection.Metadata.Ecma335;

namespace ActionAndFunctionDelegates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelegatesController : ControllerBase
    {

        [HttpPost("print", Name = "PrintToConsole")]
        public void CreateDirectory(string name)
        {
            //Using the new Keyword
            Action<string> newKeywordAction = new Action<string>(CreateDirectoryWithName);
            newKeywordAction(name);
            //Using the functionName
            Action<string> functionNameAction = CreateDirectoryWithName;
            functionNameAction(name);
            //using a lambda expression
            Action<string> lambdaAction = (string value) => Console.WriteLine(value);  
            lambdaAction(name);
        }
        private void CreateDirectoryWithName(string value)
        {
            string currentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(Path.Combine(currentPath, value)))
                Directory.CreateDirectory(Path.Combine(currentPath, value));
        }
        [HttpPost("product", Name = "Product")]
        public int GetProduct(int factor1, int factor2)
        {
            //Using the new Keyword
            Func<int, int, int> newKeywordFunction = new Func<int, int, int>(Multiply);
            int keywordProduct = newKeywordFunction(factor1, factor2);
            //Using the functionName
            Func<int, int, int> functionNameFunction = Multiply;
            int functionProduct = functionNameFunction(factor1, factor2);
            //using a lambda expression
            Func<int, int, int> lambdaFunction = (int value1, int value2) => value1 * value2 ;
            int lambdaProduct = lambdaFunction(factor1, factor2);
            return keywordProduct;
        }

        private int Multiply(int value1, int value2)
        {
            return value1 * value2;
        }



    }
}