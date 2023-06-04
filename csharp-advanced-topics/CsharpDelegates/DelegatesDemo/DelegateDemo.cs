using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class DelegateDemo
    {
        delegate int ValueUpdate(int n);
        public int Value = 10;
        public int CurrentValue()
        {
            return Value;
        }
        public int SumOperation(int p)
        {
            Value += p;
            return Value;
        }
        public int MultOperation(int q)
        {
            Value *= q;
            return Value;
        }
        public void RunDelegate()
        {
            ValueUpdate update1 = new ValueUpdate(SumOperation);
            ValueUpdate update2 = new ValueUpdate(MultOperation);

            update1(25);
            Console.WriteLine("Value of Num: {0}", CurrentValue());
            update2(5);
            Console.WriteLine("Value of Num: {0}", CurrentValue());
        }
    }
}
