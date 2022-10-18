using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAdvancedTests.Models
{
    public class Administrator : Employee
    {
        public bool AbleToFire { get; set; } = false;
    }
}
