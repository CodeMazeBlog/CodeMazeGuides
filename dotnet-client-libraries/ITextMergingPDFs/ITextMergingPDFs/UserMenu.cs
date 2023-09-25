using ITextMergingPDFs.ConsoleManager;

namespace ITextMergingPDFs
{
    public class UserMenu
    {
        private readonly IConsole _console;

        public enum UserAction
        {
            MergePdfDocumentsWithTheSameSize,
            MergePdfDocumentsWithTheDifferentSizesSize,
            MergePdfDocumentsFirstPageWithTheDifferentSizesSize,
            SplitDocumentOnOddAndEvenPages,
            ResizeDocument,
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
                '1' => UserAction.MergePdfDocumentsWithTheSameSize,
                '2' => UserAction.MergePdfDocumentsWithTheDifferentSizesSize,
                '3' => UserAction.MergePdfDocumentsFirstPageWithTheDifferentSizesSize,
                '4' => UserAction.SplitDocumentOnOddAndEvenPages,
                '5' => UserAction.ResizeDocument,
                'X' => UserAction.Exit,
                'x' => UserAction.Exit,
                _ => UserAction.Unknown
            };
        }

        public void DisplayOptions()
        {
            _console.Clear();
            _console.WriteLine("Merging PDF Documents Using iText Library\n\n");
            _console.WriteLine("Select option: \n");

            _console.WriteLine("1. Merge 3 PDF Documents with the Same Size");
            _console.WriteLine("2. Merge 3 PDF Documents with the Different Sizes");
            _console.WriteLine("3. Merge 3 PDF Documents First Page with the Different Sizes");
            _console.WriteLine("4. Split Document on Odd and Even Pages");
            _console.WriteLine("5. Resize Document");
            _console.WriteLine("X. Exit");
        }
    }
}
