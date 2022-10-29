using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneLists
{
    public class CopyToMethodExample
    {
        public string[] RunCopyToMethodExample(List<string> flist)
        {
            var fallArray = new string[flist.Count];
            flist.CopyTo(fallArray);
            return fallArray;
        }
    }
}
