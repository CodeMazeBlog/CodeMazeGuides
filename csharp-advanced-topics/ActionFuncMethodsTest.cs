using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ActionFuncDelegatesTest
{
    [TestClass]
    public class ActionFuncMethodsTest
    {
        public static void ShowWeeks(string str)
        {
            Console.WriteLine(str);
        }

        public static void GetTitleCaseMsgInAction(string msg)
        {
            string msgTitleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(msg.ToLower());
            Console.WriteLine($"Message in Title Case: {msgTitleCase}");
        }
        public static string GetTitleCaseMsgInFunc(string msg)
        {
            string msgTitleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(msg.ToLower());
            return $"Message in Title Case: {msgTitleCase}";
        }

        [TestMethod]
        public void ActionDelegate_WithoutDelegateInstance()
        {
            //*** Use of Action<T> delegate to show the data from the List<T> object ***//
            List<string> weeks = new List<string>();
            weeks.Add("Sunday");
            weeks.Add("Monday");
            weeks.Add("Tuesday");
            weeks.Add("Wednesday");
            weeks.Add("Thursday");
            weeks.Add("Friday");
            weeks.Add("Saturday");

            // Display the weeks using the ShowWeeks method
            Console.WriteLine("Name of the Weeks: ");
            weeks.ForEach(ShowWeeks);
        }
        [TestMethod]
        public void ActionDelegate_WithDelegateInstance()
        {
            //*** Use of Action<T> delegate ***//
            Console.WriteLine("\n*************Action Delegate*************");
            Action<string> message = GetTitleCaseMsgInAction;
            message("write some text here");
        }
        [TestMethod]
        public void ActionDelegate_WithAnonymousMethod()
        {
            //*** Use of Action<T> delegate with anonymous method ***//
            Console.WriteLine("\n*************Action Delegate with Anonymous Method*************");
            Action<string> strTitleCase = delegate (string str)
            {
                GetTitleCaseMsgInAction(str);
            };
            strTitleCase("write some text here");
        }
        [TestMethod]
        public void ActionDelegate_WithLambdaExpression()
        {
            //*** Use of Action<T> delegate with Lambda expression ***//
            Console.WriteLine("\n*************Action Delegate with Lambda Expression*************");
            Action<string> txtTitleCase = t => GetTitleCaseMsgInAction(t);
            txtTitleCase("write some text here");
        }
        [TestMethod]
        public void FuncDelegate_WithDelegateInstance()
        {
            //*** Use of Func delegate ***//
            Console.WriteLine("\n*************Func Delegate*************");
            Func<string, string> msgTitleCase = GetTitleCaseMsgInFunc;
            string msgOutput = msgTitleCase("write some text here");
            Console.WriteLine(msgOutput);
        }
        [TestMethod]
        public void FuncDelegate_WithAnonymousMethod()
        {
            //*** Use of Func delegate with anonymous method ***//
            Console.WriteLine("\n*************Func Delegate with Anonymous Method*************");
            Func<string, string> sTitleCase = delegate (string str)
            {
                return GetTitleCaseMsgInFunc(str);
            };
            string strResult = sTitleCase("write some text here");
            Console.WriteLine(strResult);
        }
        [TestMethod]
        public void FuncDelegate_WithLambdaExpression()
        {
            //*** Use of Func delegate with Lambda expression ***//
            Console.WriteLine("\n*************Func Delegate with Lambda Expression*************");
            Func<string, string> msgTitle = t => GetTitleCaseMsgInFunc(t);
            string res = msgTitle("write some text here");
            Console.WriteLine(res);
        }
    }
}
