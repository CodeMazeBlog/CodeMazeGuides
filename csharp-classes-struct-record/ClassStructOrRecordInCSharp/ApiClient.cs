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
