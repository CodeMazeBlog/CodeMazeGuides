using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLists
{
    public class Restaurant : ICloneable
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
