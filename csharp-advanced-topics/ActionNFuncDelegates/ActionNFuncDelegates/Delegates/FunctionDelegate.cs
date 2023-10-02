using ActionNFuncDelegates.Interfaces;

namespace ActionNFuncDelegates.Delegates
{
    /// <summary>
    /// Contains Execute function to invoke teh delegate
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public class FunctionDelegate<TInput, TOutput> : IFunctionDelegate<TInput, TOutput>
    {
        private readonly Func<TInput, TOutput> _function;
        public FunctionDelegate(Func<TInput, TOutput> function)
        {
            _function = function;
        }

        public TOutput Execute(TInput input)
        {
            return _function(input);
        }
    }
}
