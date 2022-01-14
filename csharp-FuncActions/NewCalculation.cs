using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActions
{
    public class NewCalculation
    {
        public double Range(List<double> d)
        {
            return d.Max() - d.Min();
        }
    }
}
