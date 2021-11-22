using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionAndFuncDelegateInCSharp
{
    public class ActionDelegateStore
    {
        private static readonly Dictionary<string, Action<string>> _actionMethodStore;
        private static string _reversedString;
        private static string _stringWithUnderscore;

        static ActionDelegateStore()
        {
            _actionMethodStore = new Dictionary<string, Action<string>>
            {
                ["ReverseString"] = ReverseString,
                ["AppendUnderScore"] = AppendUnderScore,
            };
        }

        public string ReversedString => _reversedString;
        public string UnderScoreString => _stringWithUnderscore;

        public Action<string> this[string key]
        {
            get
            {
                if (_actionMethodStore.ContainsKey(key))
                    return _actionMethodStore[key];

                return null;
            }
            set
            {
                _actionMethodStore[key] = value;
            }
        }

        private static void ReverseString(string word)
        {
            _reversedString = string.Join("", word.Reverse());          
        }

        private static void AppendUnderScore(string word)
        {
            _stringWithUnderscore = string.Join("", word.Append('_'));
        }
    }
}
