using Microsoft.Extensions.DependencyInjection;

namespace BuildQueryString
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IHttpClientWrapper, HttpClientWrapper>()
            .AddTransient<BooksApiService>()
            .BuildServiceProvider();

            var booksService = serviceProvider.GetRequiredService<BooksApiService>();

            Console.WriteLine("\n***************** Build the Query String Using StringConcatenation ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingStringConcatenation("George Orwell", "english"));

            Console.WriteLine("\n***************** Build the Query String Using UriBuilder Class ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingUriBuilder("Jane Austen", "english"));

            Console.WriteLine("\n***************** Build the Query String Using ParseQueryString Method ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingParseQueryStringMethod("Agatha Christie", "english"));

            Console.WriteLine("\n***************** Build the Query String Using AddQueryString Method ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingAddQueryStringMethod("Haruki Murakami", "japanese"));

            Console.WriteLine("\n***************** Build the Query String Using QueryBuilder Class ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingQueryBuilderClass("Gabriel Garcia", "spanish"));

            Console.WriteLine("\n***************** Build the Query String Using QueryString Create Method ***************\n");
            Console.WriteLine(await booksService.GetWithQueryParamsUsingCreateMethod("Leo Tolstoy", "russian"));
        }
    }
}