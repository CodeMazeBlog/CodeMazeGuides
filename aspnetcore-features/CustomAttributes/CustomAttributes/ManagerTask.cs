using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public class ManagerTask : Attribute
    {
        public Priorities Priority { get; set; }
        public bool NeedsReport { get; set; }
    }
}
