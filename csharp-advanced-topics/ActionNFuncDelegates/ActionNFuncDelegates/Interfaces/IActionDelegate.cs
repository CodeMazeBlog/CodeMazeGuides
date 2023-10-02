namespace ActionNFuncDelegates.Interfaces
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
