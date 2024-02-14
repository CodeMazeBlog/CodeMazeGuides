namespace ActionAndFuncDelegatesInCSharp.AdvancedDelegates
{
    public class Error
    {
        public string Message { get; }
        public int StatusCode { get; }
        public Error(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public string GetFullError() => $"Message: {this.Message} StatusCode:{this.StatusCode}";
    }
}
