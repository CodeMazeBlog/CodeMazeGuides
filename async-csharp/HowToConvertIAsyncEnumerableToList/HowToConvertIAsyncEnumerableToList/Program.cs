using HowToConvertIAsyncEnumerableToList;

var processor = new AsyncEnumerableProcessor();
IAsyncEnumerable<string> dataStream = processor.GetDataAsync();

List<string> dataList = await dataStream.ToListAsync();

// display each item after processing the stream
foreach (var item in dataList)
{
    Console.WriteLine(item);
}

// display each item while processing the stream
await foreach (string item in dataStream)
{
    Console.WriteLine(item);
}