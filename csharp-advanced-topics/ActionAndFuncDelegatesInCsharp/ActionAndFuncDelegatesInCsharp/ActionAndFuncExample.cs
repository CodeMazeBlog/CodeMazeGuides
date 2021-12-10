using System;

namespace ActionAndFuncDelegatesInCsharp
{
    public class Audience {
        public string Name { get; set; }
        public bool LikesChatting { get; set; }
        public int Age { get; set; }
        public string EMail { get; set; }
        //etc
    }
    public class ActionAndFuncExample
    {
        static bool AskHowAreYouIfTheyLikeChatting(Audience audience)
        {
            return audience.LikesChatting;
        }

        static void SayViaConsole(string message, Audience audience)
        {
            Console.WriteLine(message);
        }

        public static void Main(string[] args)
        {
            var jack = new Audience
            {
                Name = "Jack",
                Age = 18,
                LikesChatting = true
            };
            
            SayHi(jack, SayViaConsole, AskHowAreYouIfTheyLikeChatting);
        }

        public static void SayHi(Audience audience, Action<string, Audience> say,
            Func<Audience, bool> shouldAskHowAreYou)
        {
            say("Hi!", audience);
            if(shouldAskHowAreYou(audience))
            {
                say("How are you?", audience);
            }
        }
    }
}