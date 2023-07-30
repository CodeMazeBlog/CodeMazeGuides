using ITextHeadersFooters;
using ITextHeadersFooters.ConsoleManager;
using ITextHeadersFooters.PdfCreatorManager;

var console = new RealConsole();
var userMenu = new UserMenu(console);
var pdfCreator = new RealPdfCreator(console);

while (true)
{
    userMenu.DisplayOptions();
    var userAction = userMenu.GetSelection();

    switch (userAction)
    {
        case UserMenu.UserAction.CreateBasicDocument:
            pdfCreator.CreatePDFFile("BasicDocument", BigDocument.CreateBasicDocument);
            break;
        case UserMenu.UserAction.CreateBasicDocumentWithBigMargins:
            pdfCreator.CreatePDFFile("BasicDocumentWithBigMargins", BigDocument.CreateBasicDocumentWithBigMargins);
            break;
        case UserMenu.UserAction.AddTextAfterPageWasGenerated:
            pdfCreator.CreatePDFFile("AddTextAfterPageWasGenerated", BigDocument.AddTextAfterPageWasGenerated);
            break;
        case UserMenu.UserAction.UsageOfShowTextAlignedMethod:
            pdfCreator.CreatePDFFile("UsageOfShowTextAlignedMethod", BigDocument.UsageOfShowTextAlignedMethod);
            break;
        case UserMenu.UserAction.Classic_XofY_Footer:
            pdfCreator.CreatePDFFile("Classic_XofY_Footer", BigDocument.Classic_XofY_Footer);
            break;
        case UserMenu.UserAction.PageNumberInHeaderDateInFooter:
            pdfCreator.CreatePDFFile("PageNumberInHeaderDateInFooter", BigDocument.PageNumberInHeaderDateInFooter);
            break;
        case UserMenu.UserAction.DrawLine:
            pdfCreator.CreatePDFFile("DrawLine", BigDocument.DrawLine);
            break;
        case UserMenu.UserAction.DifferentLeftAndRightPage:
            pdfCreator.CreatePDFFile("DifferentLeftAndRightPage", BigDocument.DifferentLeftAndRightPage);
            break;
        case UserMenu.UserAction.Exit:
            return;
        case UserMenu.UserAction.Unknown:
            break;
    }

    Console.WriteLine("\n\nPress any key to continue ...");
    Console.ReadKey();
}