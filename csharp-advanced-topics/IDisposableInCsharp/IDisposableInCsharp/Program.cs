using IDisposableInCsharp;

var writer = new StreamWriterClass();

//This StreamWrite will work
writer.WriteStreamAndDisposeObject();

//This StreamWrite won't work
writer.WriteStreamAndDontDisposeObject();

writer.Dispose();
