namespace ShortCircuitEvaluationWithAsyncAwaitTests
{
    public interface IUtility
    {
        bool FirstCondition();
        Task<bool> FirstConditionAsync();
        bool SecondCondition();
        Task<bool> SecondConditionAsync();
    }
}