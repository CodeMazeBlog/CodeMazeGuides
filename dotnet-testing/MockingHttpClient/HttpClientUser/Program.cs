namespace HttpClientUser
{
    public class Program
    {
        public static HttpMessageHandler? handler { get; set; }
        public static string? jokeResponse { get; set; }
        
        public static void Main(string[] args)
        {
            string baseAddress = "https://jokes-api.herokuapp.com";
            string jokeEndpoint = $"/api/joke/500";

            HttpClient client = new HttpClient(handler!);

            var responseMessage = client.GetAsync(baseAddress + jokeEndpoint).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                jokeResponse = responseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jokeResponse);
            }
        }
    }
}