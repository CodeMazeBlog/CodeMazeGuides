using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Interfaces
{
    /// <summary>
    /// Interface for Action delegate
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IActionDelegate<TInput>
    {
        void Execute(TInput input);
    }
}
