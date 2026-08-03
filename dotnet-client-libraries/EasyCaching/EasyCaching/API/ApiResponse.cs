using System.Net;

namespace EasyCaching.API
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Result { get; set; }
        public long Duration { get; set; }
    }
}
