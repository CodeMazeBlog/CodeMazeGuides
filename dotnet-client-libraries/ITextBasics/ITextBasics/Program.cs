using ITextBasics;
using ITextBasics.ConsoleManager;
using ITextBasics.PdfCreatorManager;

var console = new RealConsole();
var userMenu = new UserMenu(console);
var pdfCreator = new RealPdfCreator(console);
var helloWorld = new HelloWorld();
var bigDocument = new BigDocument();

while (true)
{
    userMenu.DisplayOptions();
    var userAction = userMenu.GetSelection();

    if (userAction == UserMenu.UserAction.Exit)
        return;

    switch (userAction)
    {
        case UserMenu.UserAction.CreateBasicPDF:
            pdfCreator.CreatePDFFile("HelloWorld1", helloWorld.CreateBasicPDF);
            break;
        case UserMenu.UserAction.CreateAdvancedHeaderPDF:
            pdfCreator.CreatePDFFile("HelloWorld2", helloWorld.CreateAdvancedHeaderPDF);
            break;
        case UserMenu.UserAction.CreateAdvancedMoreParagraphsPDF:
            pdfCreator.CreatePDFFile("HelloWorld3", helloWorld.CreateAdvancedMoreParagraphsPDF);
            break;
        case UserMenu.UserAction.CreatePDFWithImage:
            pdfCreator.CreatePDFFile("HelloWorld4", helloWorld.CreatePDFWithImage);
            break;
        case UserMenu.UserAction.CreateBigDocument:
            pdfCreator.CreatePDFFile("BigDocument", bigDocument.Create);
            break;
    }

    Console.WriteLine("\n\nPress any key to continue ...");
    Console.ReadKey();
}