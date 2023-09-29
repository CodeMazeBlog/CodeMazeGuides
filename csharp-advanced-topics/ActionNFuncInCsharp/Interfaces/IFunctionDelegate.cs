using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Interfaces
{
    /// <summary>
    /// Interface for Function delegate
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IFunctionDelegate<TInput, TOutput>
    {
        TOutput Execute(TInput input);
    }
}
