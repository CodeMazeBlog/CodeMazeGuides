using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates.Logic
{
    public class Counter
    {
        public int Count { get; private set; }
        public Counter(int initialCount)
        {
            Count = initialCount;
        }

        public void Increment() => Count++;
        public void IncrementBy(int value) => Count += value;

        public bool IsCountEven() => Count % 2 == 0;
        public bool IsCountGreaterThanValue(int value) => Count > value;
  
    }
}
