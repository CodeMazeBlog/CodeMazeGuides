using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#region Action

Action<string> writeTextMethod = Console.WriteLine;

writeTextMethod.Invoke("Hello World!");
writeTextMethod("Hello World!");

new List<string> { "Hello", "World", "!" }.ForEach(writeTextMethod);
new List<string> { "Hello", "World", "!" }.ForEach(Console.WriteLine);

var serviceCollection = new ServiceCollection();
serviceCollection.AddLogging(builder =>
{
    builder.SetMinimumLevel(LogLevel.Debug);
});

#endregion

#region Func

Func<string, string> toUpper = input => input.ToUpper();

var words = new[] { "code", "maze" };
var wordsInUppercase = words.Select(toUpper);

foreach (var word in wordsInUppercase)
    Console.WriteLine(word);

#endregion
