using ActionNFuncDelegates.Interfaces;

namespace ActionNFuncDelegates.Delegates
{
    /// <summary>
    /// Contains Execute function to invoke the delegate
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public class ActionDelegate<TInput> : IActionDelegate<TInput>
    {
        private readonly Action<TInput> _action;

        public ActionDelegate(Action<TInput> action)
        {
            _action = action;
        }

        public void Execute(TInput input)
        {
            _action(input);
        }
    }
}
