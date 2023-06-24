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
        public ApiClient()
        {
            BaseAddress = new Uri("http://somefakeapi.com");
        }

        private string _myField = "";

        public string MyProperty { get; set; }

        public string MyMethod()
        {
            return "hello";
        }
    }
}
