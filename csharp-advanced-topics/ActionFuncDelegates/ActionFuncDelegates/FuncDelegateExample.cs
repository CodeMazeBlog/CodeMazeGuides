using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class FuncDelegateExample
    {
        public static void FuncProgram(string sentence)
        {
            Func<string, int> vowelsCountFunc = x => x.
                Count(c => new HashSet<char> { 'a', 'e', 'i', 'o', 'u' }
                .Contains(c));

            var numberOfVowels = vowelsCountFunc(sentence);

            Console.WriteLine(numberOfVowels);
        }
    }
}
