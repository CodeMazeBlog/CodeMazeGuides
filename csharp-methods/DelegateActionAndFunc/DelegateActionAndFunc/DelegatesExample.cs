using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateActionAndFunc
{
    public class DelegatesExample
    {
        // Func delegate for addition
        public Func<int, int, int> Add = (x, y) => x + y;

        // Action delegate for show Message
        public Action<string> showMessage = message => Console.WriteLine($"{message}");
    }
}
