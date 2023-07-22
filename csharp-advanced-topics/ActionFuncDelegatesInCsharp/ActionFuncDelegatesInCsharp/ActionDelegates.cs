using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesInCsharp
{
    public class ActionDelegates
    {
        //---------------------SAMPLES OF ACTION DELEGATES ------------------------------

        //We define an action delegate named LogOperation that has three input parameters
        //Action delegates does not return a value, here we assign a lambda expression to our delegate
        Action<int, int, string> LogOperation = (int x, int y, string operation) =>
        {
            switch (operation)
            {
                case "+":
                    LogInfo("Sum is: " + (x + y)); break;
                case "-":
                    LogInfo("Diff is: " + (x - y)); break;
                case "*":
                    LogInfo("Result is: " + (x * y)); break;
                case "/":
                    LogInfo("Division Result is: " + (x / y)); break;
                default:
                    LogInfo("Operation not supported!"); break;
            }
        };


        //Another action delegate, we initialized it so that it points the method DisplayText
        //According to action delegate definition DisplayText method must get a input parameter of type string and does not return a value
        Action<string> actionDelegate = new Action<string>(DisplayText);

        public void Test()
        {
            //test 1
            LogOperation(7, 19, "*");
            LogOperation(93, 3, "/");

            //test 2
            actionDelegate("Action Delegates Does Not Return A Value!");

            //test 3 : Chain Test
            ChainTest(36);
        }

        public static void LogInfo(string message)
        {
            Helper.Log("INF:{0}", message);
        }

        static void DisplayText(string message)
        {
            Helper.Log("INF:actionDelegate message is :{0}", message);
        }

        /// <summary>
        /// Action delegates are also chainable, here we attach multi methods to our action delegate
        /// </summary>
        /// <param name="testValue"></param>
        public void ChainTest(int testValue)
        {
            Action<int> myChainAction = (int value) => { };

            myChainAction += (int age) =>
            {
                Helper.Log("Your age is :{0}", age);
            };

            myChainAction += (int examScore) =>
            {
                Helper.Log("Your Exam score is :{0}", Math.Min(examScore * 1.8, 100));
            };

            myChainAction += (int value) =>
            {
                Helper.Log("This number is {0}", value % 2 != 0 ? "ODD" : "EVEN");
            };

            //Invoke delegate
            Helper.Log("-----");
            myChainAction(testValue);
        }
    }
}
