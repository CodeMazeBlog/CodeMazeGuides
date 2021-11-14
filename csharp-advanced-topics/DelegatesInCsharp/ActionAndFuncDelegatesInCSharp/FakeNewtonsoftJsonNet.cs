using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    /// <summary>
    /// This is not the JSON serializer you are looking for.
    /// Used for demonstrating a JSON.NET-like interface without adding a nuget.
    /// </summary>
    public static class JsonConvert
    {
        public static string SerializeObject(object input) => input.ToString();
    }
}
