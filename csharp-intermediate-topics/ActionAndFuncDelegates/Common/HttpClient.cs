using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Common
{
    public class HttpClient : IHttpClient
    {
        public TResponseBody SendGetRequest<TResponseBody>(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using HttpWebResponse response = (HttpWebResponse)(request.GetResponse());
            using StreamReader reader = new(response.GetResponseStream());
            return JsonConvert.DeserializeObject<TResponseBody>(reader.ReadToEnd());
        }
    }
}
