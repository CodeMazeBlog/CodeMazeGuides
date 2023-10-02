namespace ActionNFuncDelegates.Interfaces
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
