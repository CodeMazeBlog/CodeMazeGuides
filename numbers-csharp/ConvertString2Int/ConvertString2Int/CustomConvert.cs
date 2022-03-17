using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertString2Int
{
    public static class CustomConvert
    {
        public static int Parse(string strVal)
        {
            var num = 0;

            for (int i = 0; i < strVal.Length; i++)
            {
                num = num * 10 + (strVal[i] - '0');
            }

            return num;
        }
    }
}
