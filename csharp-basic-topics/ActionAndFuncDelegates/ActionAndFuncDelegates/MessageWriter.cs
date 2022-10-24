namespace ActionAndFuncDelegates
{
    public class MessageWriter
    {
        private readonly string messagePrefix;

        private readonly TextWriter output;

        public MessageWriter(string messagePrefix) : this(messagePrefix, Console.Out)
        {}

        public MessageWriter(string messagePrefix, TextWriter output)
        {
            this.messagePrefix = messagePrefix;
            this.output = output;
        }

        public void ReportElementFound(int x) => output.WriteLine($"{messagePrefix}: {x} is found.");
        public void ReportElementNotFound(int x) => output.WriteLine($"{messagePrefix}: {x} not found.");
    }
}