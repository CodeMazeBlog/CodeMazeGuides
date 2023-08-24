using ITextHeadersFooters.ConsoleManager;

namespace ITextHeadersFooters
{
    public class UserMenu
    {
        private readonly IConsole _console;

        public enum UserAction
        {
            CreateBasicDocument,
            CreateBasicDocumentWithBigMargins,
            AddTextAfterPageWasGenerated,
            UsageOfShowTextAlignedMethod,
            Classic_XofY_Footer,
            PageNumberInHeaderDateInFooter,
            DrawLine,
            DifferentLeftAndRightPage,
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
                '1' => UserAction.CreateBasicDocument,
                '2' => UserAction.CreateBasicDocumentWithBigMargins,
                '3' => UserAction.AddTextAfterPageWasGenerated,
                '4' => UserAction.UsageOfShowTextAlignedMethod,
                '5' => UserAction.Classic_XofY_Footer,
                '6' => UserAction.PageNumberInHeaderDateInFooter,
                '7' => UserAction.DrawLine,
                '8' => UserAction.DifferentLeftAndRightPage,
                'X' => UserAction.Exit,
                'x' => UserAction.Exit,
                _ => UserAction.Unknown
            };
        }

        public void DisplayOptions()
        {
            _console.Clear();
            _console.WriteLine("Adding Headers and Footers Using Itext Library\n\n");
            _console.WriteLine("Select option: \n");

            _console.WriteLine("1. Create basic long PDF document");
            _console.WriteLine("2. Create long document with big margins");
            _console.WriteLine("3. Add text after page was generated");
            _console.WriteLine("4. Usage of ShowTextAligned method");
            _console.WriteLine("5. Classic X of Y footer");
            _console.WriteLine("6. Page number in the header, date in the footer");
            _console.WriteLine("7. Draw line in the header / footer");
            _console.WriteLine("8. Different left and right page");
            _console.WriteLine("X. Exit");
        }
    }
}
