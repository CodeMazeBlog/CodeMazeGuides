using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncInCsharp.Interfaces
{
    public interface IProgress
    {
        public string Message { get; }
        public string BarDrawing { get; }
        public double Value { get; }
    }
}
