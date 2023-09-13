using MediatR;

namespace MediatrExceptionHandler
{
    public class BaseResponse
    {
        public string Message { get; set; } = null!;
    }

    public class SomeResponse : BaseResponse { }
}
