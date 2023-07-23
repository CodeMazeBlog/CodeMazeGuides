using ITextBasics.ConsoleManager;

namespace ITextBasics
{
    public class UserMenu
    {
        private readonly IConsole _console;

        public enum UserAction
        {
            CreateBasicPDF,
            CreateAdvancedHeaderPDF,
            CreateAdvancedMoreParagraphsPDF,
            CreatePDFWithImage,
            CreateBigDocument,
            Exit,
            Unknown
        }

        public UserMenu(IConsole console)
        {
            _console = console;
        }

        public UserAction GetSelection()
        {
            _console.Write("\n\n Your selection ... ");
            var key = _console.ReadKey();

            return key.KeyChar switch
            {
                '1' => UserAction.CreateBasicPDF,
                '2' => UserAction.CreateAdvancedHeaderPDF,
                '3' => UserAction.CreateAdvancedMoreParagraphsPDF,
                '4' => UserAction.CreatePDFWithImage,
                '5' => UserAction.CreateBigDocument,
                'X' => UserAction.Exit,
                'x' => UserAction.Exit,
                _ => UserAction.Unknown
            };
        }

        public void DisplayOptions()
        {
            _console.Clear();
            _console.WriteLine("Welcome to basic PDF manipulation using iText library\n\n");
            _console.WriteLine("Select option: \n");

            _console.WriteLine("1. Create basic 'Hello world' PDF file");
            _console.WriteLine("2. Create 'Hello world' PDF file with bigger font, right aligned text, surrounded with border");
            _console.WriteLine("3. Create multiline 'Hello world' PDF file");
            _console.WriteLine("4. Create 'Hello world' PDF file with image");
            _console.WriteLine("5. Create PDF file with few paragraphs");
            _console.WriteLine("X. Exit");
        }
    }
}
