using System.Net;
using System.Text;

namespace SimpleHTTPServer;

public class ChunkUploadServer
{
	readonly int chunkSize;
	readonly int threadCount;

	public ChunkUploadServer(int chunkSize, int threadCount)
	{
		this.chunkSize = chunkSize;
		this.threadCount = threadCount;
	}

	public async Task StartServer(int port)
	{
		var uri = $"http://localhost:{port}/upload/";

		var listener = new HttpListener();
		listener.Prefixes.Add(uri);
		listener.Start();

		Console.WriteLine($"Server started listening at {uri}");

		// Wait for a client request
		var context = await listener.GetContextAsync();
		if (context.Request.HttpMethod == HttpMethod.Post.Method)
		{
			await ProcessUpload(context);
		}
		else
		{
			context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
			context.Response.Close();
		}
	}

	public async Task ProcessUpload(HttpListenerContext context)
	{
		var fileName = Path.GetFileName(context.Request.Headers["X-Filename"]);

		if (context.Request.ContentLength64 > chunkSize * threadCount)
		{
			Console.WriteLine("File size exceeds chunk capacity.");
			context.Response.Abort();
			return;
		}

		var barrier = new Barrier(threadCount + 1);

		for (int i = 0; i < threadCount; i++)
		{
			int chunkNumber = i + 1;
			var threadTask = Task.Run(() =>
			{
				Console.WriteLine($"Thread {chunkNumber} processed stream chunk.");

				barrier.SignalAndWait();
			});
		}

		barrier.SignalAndWait();

		var message = $"File '{fileName}' uploaded successfully...";

		context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(message);
		context.Response.StatusCode = (int)HttpStatusCode.Created;

		using (Stream s = context.Response.OutputStream)
		using (StreamWriter writer = new StreamWriter(s))
			await writer.WriteAsync(message);

		context.Response.Close();
	}
}