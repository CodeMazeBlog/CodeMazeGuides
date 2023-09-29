using Microsoft.Extensions.DependencyInjection;

namespace BuildQueryString
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IHttpClientWrapper, HttpClientWrapper>()
            .AddTransient<QueryStringService>()
            .BuildServiceProvider();

            var booksService = serviceProvider.GetRequiredService<QueryStringService>();

            Console.WriteLine("\n***************** Build the Query String Using StringConcatenation ***************\n");
            await booksService.BuildQueryStringUsingStringConcat("rowling", "english");

            Console.WriteLine("\n***************** Build the Query String Using StringConcatenation With Encoding ***************\n");
            await booksService.BuildQueryStringByEncoding("George Orwell", "english");

            Console.WriteLine("\n***************** Build the Query String Using UriBuilder Class ***************\n");
            await booksService.BuildQueryStringUsingUriBuilder("Jane Austen", "english");

            Console.WriteLine("\n***************** Build the Query String Using ParseQueryString Method ***************\n");
            await booksService.BuildQueryStringUsingParseQueryStringMethod("Agatha Christie", "english");

            Console.WriteLine("\n***************** Build the Query String Using AddQueryString Method ***************\n");
            await booksService.BuildQueryStringUsingAddQueryStringMethod("Haruki Murakami", "japanese");

            Console.WriteLine("\n***************** Build the Query String Using QueryBuilder Class ***************\n");
            await booksService.BuildQueryStringUsingQueryBuilderClass("Gabriel Garcia", "spanish");

            Console.WriteLine("\n***************** Build the Query String Using QueryString Create Method ***************\n");
            await booksService.BuildQueryStringUsingCreateMethod("Leo Tolstoy", "russian");
        }
    }
}