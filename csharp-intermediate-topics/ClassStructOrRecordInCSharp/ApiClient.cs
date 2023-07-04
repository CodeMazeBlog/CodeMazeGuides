using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructOrRecordInCSharp
{
    public class ApiClient : HttpClient
    {
        private string _myField = "";

        public string MyProperty { get; set; }

        public ApiClient()
        {
            BaseAddress = new Uri("http://somefakeapi.com");
        }

        public string MyMethod()
        {
            return "hello";
        }
    }
}
