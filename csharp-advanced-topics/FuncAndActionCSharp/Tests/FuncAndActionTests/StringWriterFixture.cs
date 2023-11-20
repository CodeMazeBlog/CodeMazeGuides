namespace FuncAndActionCSharpTests
{
    public class StringWriterFixture : IDisposable
    {
       public StringWriter Writer { get; private set; } 

        public StringWriterFixture() 
        {
            Writer = new StringWriter();    
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
