namespace IDisposableInCsharp
{
    public class StreamWriterClass : IDisposable
    {
        public void WriteStreamAndDisposeObject()
        {
            var fileName = Guid.NewGuid() + ".txt";

            var firstWriter = new StreamWriter(fileName);
            firstWriter.WriteLine("New line written in the txt file.");
            firstWriter.Dispose();

            var secondWriter = new StreamWriter(fileName);
            secondWriter.WriteLine("Since dispose already run, it works and file can be written again.");
            secondWriter.Dispose();

            Dispose();
        }
        public void WriteStreamAndDontDisposeObject()
        {

            try
            {
                var fileName = Guid.NewGuid() + ".txt";
                var firstWriter = new StreamWriter(fileName);
                firstWriter.WriteLine("New line written in the txt file.");

                var secondWriter = new StreamWriter(fileName);
                secondWriter.WriteLine("Since this file is already open, it won't work. The file is already opened by the other StreamWrite object in memory.");
            }
            catch (IOException exception)
            {
                Console.WriteLine("Method exception due to " + exception?.Message);
                Dispose();
            }


        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}