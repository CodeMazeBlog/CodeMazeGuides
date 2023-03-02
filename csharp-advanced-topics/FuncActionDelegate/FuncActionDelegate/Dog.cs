using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionDelegate
{
    public class Dog
    {
        public string MakeSound(string sound)
        {
            return sound;
        }
        public void PrintSound(string sound) 
        { 
            Console.WriteLine(sound);
        }
}
}
