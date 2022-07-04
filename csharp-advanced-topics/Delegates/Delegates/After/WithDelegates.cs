using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.After
{
    public class WithDelegates
    {
        public static string PrintProcessedText(string text, Action<string> print, Func<string, string> operation)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (print == null)
                throw new ArgumentNullException("print");
            if (operation == null)
                throw new ArgumentNullException("operation");

            text = operation(text);
            print(text);
            return text;
        }
    }
}
