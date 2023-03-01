using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class Finder
    {
        #region Find
        public static int FindOnlyOne(int[] list, int input)
        {
            int index = -1;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == input)
                {
                    if (index != -1)
                        throw new Exception();
                    index = i;
                }
            }
            if (index == -1)
                throw new Exception();
            return index;
        }
        public static int FindLastIndex(int[] list, int input)
        {
            // Find last index using lambda
            Func<int[], int, int> find = (list, input) =>
            {
                int index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == input)
                    {
                        index = i;
                    }
                }
                return index;
            };
            return find.Invoke(list, input);
        }
        public static int FindMaximumOne(int[] list, int input)
        {
            Func<int[], int, int> find = delegate (int[] list, int input)
            {
                int index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] == input)
                    {
                        if (index != -1)
                            throw new Exception();
                        index = i;
                    }
                }
                return index;

            };
            return find.Invoke(list, input);
        }
        #endregion
    }
}
