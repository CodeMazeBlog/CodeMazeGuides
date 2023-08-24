using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToDetectIfADictionaryKeyExistsInCsharp
{
    public class MyClassWithEquality
    {
        public int MyNumber { get; set; }

        public MyClassWithEquality(int num)
        {
            MyNumber = num;
        }

        public bool Equals(MyClassWithEquality other)
        {
            if (this.MyNumber != other.MyNumber) return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            if (obj is not MyClassWithEquality) return false;
            if (obj == null) return false;
            return Equals(obj as MyClassWithEquality);
        }

        public override int GetHashCode()
        {
            return MyNumber;
        }
    }
}
