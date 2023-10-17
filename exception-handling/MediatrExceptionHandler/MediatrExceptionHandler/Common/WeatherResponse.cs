namespace MediatrExceptionHandler
{
    public class BaseResponse
    {
        public bool HasError { get; set; }
        public string Message { get; set; } = null!;
    }

    public class WeatherResponse : BaseResponse { }
}
