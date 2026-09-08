using SimpleHTTPServer;

class Program
{
	public static void Main(string[] args)
	{
		var port = 8090;
		var chunkSize = 1024 * 1024;
		var threadCount = 4;

		var server = new ChunkUploadServer(chunkSize, threadCount);
		server.StartServer(port).Wait();
	}
}
