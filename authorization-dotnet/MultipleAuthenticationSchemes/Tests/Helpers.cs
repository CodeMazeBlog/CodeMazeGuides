using Newtonsoft.Json;
using System.Text;

namespace Tests
{
    public static class Helpers
    {
        public static class ContentHelper
        {
            public static StringContent GetStringContent(object obj)
                => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
        }

        public static async Task<string> GetToken(HttpResponseMessage loginJwtResponse)
        {
            var dictionaryResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(await loginJwtResponse.Content.ReadAsStringAsync());
            return dictionaryResponse["token"];

        }
    }
}
