using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateDemo_DemoGate
{
    public class ActionDelegate
    {
        public static string sentence;
        public static string sentence1;
        public static string sentence2;
        

        public void ActionDelegates()
        {
            Action<string, string> Sentence = MakeSentence;
            Sentence("I think.", " Therefore I am.");
            Console.WriteLine($"Sentence = {sentence}");

            Action<string, string> Sentence1 = delegate (string phrase1, string phrase2)
            {
                sentence1 = phrase1 + phrase2;
            };
            Sentence1("I think.", " Therefore I am.");
            Console.WriteLine(sentence1);

            Action<string, string> Sentence2 = (phrase1, phrase2) => sentence2 = phrase1 + phrase2;
            Sentence2("I think.", " Therefore I am.");
            Console.WriteLine(sentence2);
        }

        private static void MakeSentence(string phrase1, string phrase2)
        {
            sentence = phrase1 + phrase2;
        }
    }
}
