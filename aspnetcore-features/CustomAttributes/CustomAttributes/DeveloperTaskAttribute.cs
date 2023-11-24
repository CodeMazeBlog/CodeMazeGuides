using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DeveloperTaskAttribute : Attribute
    {
        public DeveloperTaskAttribute(Priorities priority)
        {
            Priority = priority;
        }

        public Priorities Priority { get; set; }
        public string? Description { get; set; }
    }
}
