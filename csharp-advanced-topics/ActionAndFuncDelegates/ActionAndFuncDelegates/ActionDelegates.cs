namespace ActionAndFuncDelegates
{
    public class ActionDelegates : Common
    {
        public ActionDelegates(string[] input, string substring)
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
            }
        }

        //Action delegate invoke parameterless method
        public static void ActionDelegateParameterlessMethod()
        {            
            Action ActionWithParameterlessMethod = PrintMessageOnConsole;
            ActionWithParameterlessMethod();
        }

        // Action delegate invoke parameterized method
        public void ActionDelegateWithParameterizedMethod()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }
            
            Action<string[], string> ActionWithParameterizedMethod = ParameterizedMethod;

            ActionWithParameterizedMethod(Arr, Substring);
        }

        //Action delegate invoke Anonymous method
        public void ActionDelegateWithAnonymousMethod()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }
            
            Action<string[], string> ActionWithAnonymousMethod = delegate (string[] list, string substring)
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with Anonymous method:");

                Results = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring))
                .ToList();

                PrintFilteredList(Results);
            };

            ActionWithAnonymousMethod(Arr, Substring);
        }

        // Action delegate invoke Lambda expression 
        public void ActionDelegateWithLambdaExpression()
        {
            if (!IsValidInputFlag)
            {
                //Message = "Input Error!!";
                //Console.WriteLine(Message);
                return;
            }

            Action<string[], string> ActionWithLambdaExp = (string[] list, string substring) =>
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with Lambda Expression:");

                Results = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring))
                .ToList();

                PrintFilteredList(Results);
            };

            ActionWithLambdaExp(Arr, Substring);
        }

        public static void PrintMessageOnConsole()
        {
            Console.WriteLine("Action Delegate invoked a parameterless method. \n");
        }

        public void ParameterizedMethod(string[] list, string substring)
        {
            if (list != null && list.Length != 0 && !string.IsNullOrEmpty(substring))
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with parameterized method:");

                Results = list.Select(i => i.ToString())
                    .Where(i => i.ToLower().Contains(substring))
                    .ToList();

                PrintFilteredList(Results);
            }
            else
            { 
                Console.WriteLine("Incorrect input");
            }
        }
    }
}
