using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLists
{
    public class ToListExample
    {
        public List<string>? clonedCarList { get; set; }
        public List<string> RunToListExample(List<string> slist)
        {            
            return CloneList(slist);
        }

        public List<string> CloneList(List<string> slist)
        {
            return slist.ToList();
        }

    }
}
