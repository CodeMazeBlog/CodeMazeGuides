using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UsingAuthorizationWithSwagger.Models;

namespace Test.Helpers
{
    public static class HelperClass
    {
        public static class ContentHelper
        {
            public static StringContent GetStringContent(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
        }                     
       
    }
}
