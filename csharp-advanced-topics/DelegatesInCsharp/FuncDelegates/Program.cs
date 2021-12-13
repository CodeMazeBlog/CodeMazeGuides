using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FuncDelegates
{
    class Program
    {
        static string GetTitleCaseMessage(string msg)
        {
            string msgTitleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(msg.ToLower());
            return $"Message in Title Case: {msgTitleCase}";
        }

        static void Main(string[] args)
        {
            //*** Use of Func delegate ***//
            Console.WriteLine("\n*************Func Delegate*************");
            Func<string, string> message = GetTitleCaseMessage;
            string result = message("write some text here");
            Console.WriteLine(result);

            //*** Use of Func delegate with anonymous method ***//
            Console.WriteLine("\n*************Func Delegate with Anonymous Method*************");
            Func<string, string> strTitleCase = delegate (string str)
                                                {
                                                    return GetTitleCaseMessage(str);
                                                };
            string strResult = strTitleCase("write some text here");
            Console.WriteLine(strResult);

            //*** Use of Func delegate with Lambda expression ***//
            Console.WriteLine("\n*************Func Delegate with Lambda Expression*************");
            Func<string, string> txtTitleCase = t => GetTitleCaseMessage(t);
            string res = txtTitleCase("write some text here");
            Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
