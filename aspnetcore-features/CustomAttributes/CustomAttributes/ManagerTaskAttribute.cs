using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class ManagerTaskAttribute : Attribute
    {
        public Priorities Priority { get; set; }
        public bool NeedsReport { get; set; }
    }
}
