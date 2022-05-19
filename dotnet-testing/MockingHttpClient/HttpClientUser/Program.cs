namespace HttpClientUser
{
    public class Program
    {
        public static HttpMessageHandler? Handler { get; set; }
        public static string? Response { get; set; }
        public static HttpClient Client = new HttpClient();
        
        public static void Main(string[] args)
        {
            if (Handler is not null)
            { 
                Client = new HttpClient(Handler);
            }

            string baseAddress = "https://reqres.in";
            string apiEndpoint = "/api/users/2";

            var responseMessage = Client.GetAsync(baseAddress + apiEndpoint).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                Response = responseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(Response);
            }
        }
    }
}