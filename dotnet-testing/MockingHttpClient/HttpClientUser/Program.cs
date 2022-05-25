namespace HttpClientUser
{
    public class Program
    {
        public static HttpMessageHandler? Handler { get; set; }
        public static string? Response { get; set; }
        public static HttpClient Client = new HttpClient();
        
        public static async Task Main(string[] args)
        {
            if (Handler is not null)
            { 
                Client = new HttpClient(Handler);
            }

            string baseAddress = "https://reqres.in";
            string apiEndpoint = "/api/users/2";

            var responseMessage = await Client.GetAsync(baseAddress + apiEndpoint);

            if (responseMessage.IsSuccessStatusCode)
            {
                Response = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(Response);
            }
        }
    }
}