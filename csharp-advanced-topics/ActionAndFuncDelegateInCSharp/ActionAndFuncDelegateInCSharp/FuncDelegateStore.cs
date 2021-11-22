using System;
using System.Collections.Generic;

namespace ActionAndFuncDelegateInCSharp
{
    public class FuncDelegateStore
    {
        private static Dictionary<string, Func<string, int>> FuncMethodStore;

        static FuncDelegateStore()
        {
            FuncMethodStore = new Dictionary<string, Func<string, int>>
            {
                ["CheckStringLength"] = CheckStringLength,
                ["MultiplyStringLength"] = MultiplyStringLength
            };
        }

        public Func<string, int> this[string key]
        {
            get
            {
                if (FuncMethodStore.ContainsKey(key))
                    return FuncMethodStore[key];

                return null;
            }
            set
            {
                FuncMethodStore[key] = value;
            }
        }

        private static int CheckStringLength(string word)
        {
            return word.Length;
        }

        private static int MultiplyStringLength(string word)
        {
            return word.Length * 2;
        }
    }
}
