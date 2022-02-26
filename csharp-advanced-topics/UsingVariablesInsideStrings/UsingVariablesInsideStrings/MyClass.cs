using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingVariablesInsideStrings
{
    public class MyClass
    {
        public int MyNumber { get; set; }
        public MyClass(int num)
        {
            MyNumber = num;
        }
        public override string ToString()
        {
            return MyNumber.ToString();
        }
    }
}
