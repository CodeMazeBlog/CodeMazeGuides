using System.Net;

namespace MediatrExceptionHandler
{
    public class BaseResponse
    {
        public string Message { get; set; } = null!;
    }

    public class WeatherResponse : BaseResponse { }
}
