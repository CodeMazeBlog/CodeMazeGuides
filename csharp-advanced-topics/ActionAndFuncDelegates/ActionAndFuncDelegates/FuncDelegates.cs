namespace ActionAndFuncDelegates
{
    public class FuncDelegates : Common
    {
        public FuncDelegates(string[] input, string substring)
        {
            Substring = substring;
            Arr = input;
            if (input != null && input.Length != 0 && !string.IsNullOrEmpty(substring))
            {                
                IsValidInputFlag = true;
                Message = string.Empty;
            }
            else
            {
                IsValidInputFlag = false;
                Message = "Input Error!!";
                Console.WriteLine(Message);
            }
        }

        //Func delegate invoke parameterless method
        public static void FuncDelegateWithParameterlessMethod()
        {
            Func<string> FuncWithParameterlessMethod = PrintMessageOnConsole;

            string temp = FuncWithParameterlessMethod();

            Console.WriteLine(temp);
        }

        // Func delegate invoke parameterized method
        public void FuncDelegateWithParameterizedMethod()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }

            Func<string[], string, List<string>> FuncWithParameterizedMethod = ParameterizedMethod;

            Results = new();
            Results = FuncWithParameterizedMethod(Arr, Substring);
            PrintFilteredList(Results);
        }

        //Func delegate invoke Anonymous method
        public void FuncDelegateWithAnonymousMethod()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }

            Func<string[], string, List<string>> FuncWithAnonMethod = delegate (string[] list, string substring)
            {
                List<string> filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring))
                .ToList();

                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with Anonymous method:");                

                return filteredList;
            };

            Results = new();
            Results = FuncWithAnonMethod(Arr, Substring);
            PrintFilteredList(Results);
        }

        // Func delegate invoke Lambda expression 
        public void FuncDelegateWithLambdaExpression()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }

            Func<string[], string, List<string>> FuncWithLambdaExp = (string[] list, string substring) =>
            {
                List<string> filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring))
                .ToList();

                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with lambda expression:");                

                return filteredList;
            };

            Results = new();
            Results = FuncWithLambdaExp(Arr, Substring);
            PrintFilteredList(Results);
        }

        public static string PrintMessageOnConsole()
        {
            return "Func Delegate invoked a parameterless method called. \n";
        }

        public static List<string> ParameterizedMethod(string[] list, string substring)
        {
            Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with parameterized method:");

            List<string> filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring))
                .ToList();

            return filteredList;
        }
    }
}
