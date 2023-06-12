namespace RetryLogic.Exceptions
{
    public class RetryException : Exception
    {
        public RetryException(string? message) : base(message)
        {
        }
    }
}
