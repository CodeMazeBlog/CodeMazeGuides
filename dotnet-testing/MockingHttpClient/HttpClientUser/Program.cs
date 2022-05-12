using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HttpClientUser
{
    public class Program
    {
        public static HttpMessageHandler handler;
        
        public static void Main(string[] args)
        {
            string baseAddress = "https://jokes-api.herokuapp.com";
            string jokeEndpoint = $"/api/joke/500";

            HttpClient client = new HttpClient(handler);

            var responseMessage = client.GetAsync(baseAddress + jokeEndpoint).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                var jokeJSON = responseMessage.Content.ReadAsStringAsync().Result;
                //Joke joke = JsonSerializer.Deserialize<Joke>(jokeJSON)!;
                Console.WriteLine(jokeJSON);
            }
        }
    }

    public class Joke
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("value")]
        public JokeValue Value { get; set; } = default!;
    }

    public class JokeValue
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("joke")]
        public string Joke { get; set; }
    }
}