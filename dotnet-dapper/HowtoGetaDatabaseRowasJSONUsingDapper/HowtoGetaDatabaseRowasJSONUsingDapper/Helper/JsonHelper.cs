using Newtonsoft.Json;

namespace HowtoGetaDatabaseRowasJSONUsingDapper.Helper
{
    public static class JsonHelper
    {
        public static string ConvertToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
