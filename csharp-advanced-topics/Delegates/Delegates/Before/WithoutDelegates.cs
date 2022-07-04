using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Before
{
    public class WithoutDelegates
    {
        public static string PrintInUpperCase(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            text = text.ToUpper();
            Console.WriteLine("Print in Upper Case: {0}", text);
            return text;
        }

        public static string PrintInLowerCase(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            text = text.ToLower();
            Console.WriteLine("Print in Lower Case: {0}", text);
            return text;
        }

    }
}
