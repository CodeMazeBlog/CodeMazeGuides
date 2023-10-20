using HowToConvertIAsyncEnumerableToList;

var processor = new AsyncEnumerableProcessor();
_ = await processor.ProcessDataUsingToListAsync();
_ = await processor.ProcessDataUsingAsyncForeachAsync();
