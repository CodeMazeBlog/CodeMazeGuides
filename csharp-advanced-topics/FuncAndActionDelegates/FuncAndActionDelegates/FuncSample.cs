using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegates
{
    public class FuncSample
    {
         Func<string, string, string> SayMessage;
        
        public FuncSample()
        {
            SayMessage = SayHello;
            Console.WriteLine(SayMessage("John", "How are you?"));
        }
        public string SayHello(string name, string message)
        {          
            return string.Format("Hello {0}, {1}", name, message);
        }
    }

    public class FuncAsParam
    {
        public FuncAsParam()
        {
            Func<string, string> Explain = (string explanation) =>
            {
                return $"It's been passed as {explanation} here.";
            };

            DisplayExplanationText(Explain);
            // It's been passed as parameter here.
        }

        public void DisplayExplanationText(Func<string, string> SayExplanation)
        {
            Console.WriteLine(SayExplanation("parameter"));
        }
    }
}
