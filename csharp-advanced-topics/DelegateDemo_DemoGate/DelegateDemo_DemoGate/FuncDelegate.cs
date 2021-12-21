using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateDemo_DemoGate
{
    
    public class FuncDelegate
    {
        public string FuncDelegates()
        {
            Func<string, string, string> Sentence1 = MakeSentence;
            string sentence1 = Sentence1("1: I think.", " Therefore I am.");
            Console.WriteLine($"Sentence = {sentence1}");

            Func<string, string, string> Sentence2 = delegate (string phrase1, string phrase2)
            {
                return phrase1 + phrase2;
            };
            string sentence2 = Sentence2("2: I think.", " Therefore I am.");
            Console.WriteLine($"Sentence = {sentence2}");
            //return sentence2;



            Func<string, string, string> Sentence3 = (phrase1, phrase2) => phrase1 + phrase2;
            string sentence3 = Sentence3("3: I think.", " Therefore I am.");
            Console.WriteLine($"Sentence = {sentence3}");
            

            return sentence1;
        }

        public string MakeSentence(string phrase1, string phrase2)
        {
            return phrase1 + phrase2;
        }
    }
}
