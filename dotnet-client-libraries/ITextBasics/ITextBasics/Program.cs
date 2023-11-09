using ITextBasics;
using ITextBasics.ConsoleManager;
using ITextBasics.PdfCreatorManager;

var console = new RealConsole();
var userMenu = new UserMenu(console);
var pdfCreator = new RealPdfCreator(console);

while (true)
{
    userMenu.DisplayOptions();
    var userAction = userMenu.GetSelection();

    switch (userAction)
    {
        case UserMenu.UserAction.CreateBasicPDF:
            pdfCreator.CreatePDFFile("HelloWorld1", HelloWorld.CreateBasicPDF);
            break;
        case UserMenu.UserAction.CreateAdvancedHeaderPDF:
            pdfCreator.CreatePDFFile("HelloWorld2", HelloWorld.CreateAdvancedHeaderPDF);
            break;
        case UserMenu.UserAction.CreateAdvancedMoreParagraphsPDF:
            pdfCreator.CreatePDFFile("HelloWorld3", HelloWorld.CreateAdvancedMoreParagraphsPDF);
            break;
        case UserMenu.UserAction.CreatePDFWithImage:
            pdfCreator.CreatePDFFile("HelloWorld4", HelloWorld.CreatePDFWithImage);
            break;
        case UserMenu.UserAction.CreateBigDocument:
            pdfCreator.CreatePDFFile("BigDocument", BigDocument.Create);
            break;
        case UserMenu.UserAction.Exit:
            return;
        case UserMenu.UserAction.Unknown:
            break;
    }

    Console.WriteLine("\n\nPress any key to continue ...");
    Console.ReadKey();
}