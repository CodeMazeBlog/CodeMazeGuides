using SimpleHTTPServer;

class Program
{
	public static void Main(string[] args)
	{
		int port = 8080;
		int chunkSize = 1024 * 1024; // 1 MB chunk size
		int threadCount = 4; // 4 participant threads

		var server = new ChunkUploadServer(chunkSize, threadCount);
		server.StartServer(port).Wait();
	}
}
