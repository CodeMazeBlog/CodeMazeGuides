namespace MediatrExceptionHandler
{
    public class BaseResponse
    {
        public int? ErrorCode { get; set; }
        public string Message { get; set; } = null!;
    }

    public class WeatherResponse : BaseResponse { }
}
