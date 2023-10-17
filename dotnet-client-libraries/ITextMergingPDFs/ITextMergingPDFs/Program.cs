using iText.Kernel.Geom;
using ITextMergingPDFs;
using ITextMergingPDFs.ConsoleManager;
using System.Diagnostics;

var console = new RealConsole();
var userMenu = new UserMenu(console);

while (true)
{
    userMenu.DisplayOptions();
    var userAction = userMenu.GetSelection();

    switch (userAction)
    {
        case UserMenu.UserAction.MergePdfDocumentsWithTheSameSize:
            RunMergeExample(nameof(UserMenu.UserAction.MergePdfDocumentsWithTheSameSize),
                (documentsManager) => documentsManager.CreateFewDocuments("document{0}.pdf", 3, PageSize.A4));
            break;
        case UserMenu.UserAction.MergePdfDocumentsWithTheDifferentSizesSize:
            RunMergeExample(nameof(UserMenu.UserAction.MergePdfDocumentsWithTheDifferentSizesSize),
                (documentsManager) => documentsManager.CreateFewDocuments("document{0}.pdf", 3));
            break;
        case UserMenu.UserAction.MergePdfDocumentsFirstPageWithTheDifferentSizesSize:
            RunMergeExample(nameof(UserMenu.UserAction.MergePdfDocumentsFirstPageWithTheDifferentSizesSize),
                (documentsManager) => documentsManager.CreateFewDocuments("document{0}.pdf", 3),
                onlyFirstPage: true);
            break;
        case UserMenu.UserAction.SplitDocumentOnOddAndEvenPages:
            RunSplitExample(nameof(UserMenu.UserAction.SplitDocumentOnOddAndEvenPages));
            break;
        case UserMenu.UserAction.ResizeDocument:
            RunScaleExample(nameof(UserMenu.UserAction.ResizeDocument));
            break;
        case UserMenu.UserAction.Exit:
            return;
        case UserMenu.UserAction.Unknown:
            break;
    }

    Console.WriteLine("\n\nPress any key to continue ...");
    Console.ReadKey();
}

void DisplayPDFFile(string pdfFileName)
{
    using var process = new Process
    {
        StartInfo = new ProcessStartInfo(pdfFileName)
        {
            CreateNoWindow = true,
            UseShellExecute = true
        }
    };

    process.Start();
}

void RunMergeExample(string folderName, Func<BigDocument, string[]> createExampleDocumentsFunction, bool onlyFirstPage = false)
{
    console.Clear();

    var folderManager = FolderManager.CreateFolderManagerAsProgramSubfolder(folderName);
    var pdfFolder = folderManager.PdfFolderName;

    try
    {
        folderManager.RecreatePFDDocumentsFolder();
    }
    catch (Exception)
    {
        Console.WriteLine($"You seem to already have a PDF file open in a folder {pdfFolder}. Please close all PDF files to process with this example.");
        return;
    }

    var documentsManager = new BigDocument(pdfFolder);
    var merger = new Merger(pdfFolder);

    console.WriteLine("\n\nCreating documents ...\n");
    var documents = createExampleDocumentsFunction(documentsManager);
    foreach (var document in documents)
    {
        console.WriteLine($" * Document {document} created.");
        DisplayPDFFile(document);
    }

    console.WriteLine("\n\nMerging documents ...\n");
    var merged = (onlyFirstPage)
        ? merger.MergePDFsFirstPage(documents, "merged.pdf")
        : merger.MergePDFs(documents, "merged.pdf");

    console.WriteLine($"\nDocuments merged into {merged}");
    DisplayPDFFile(merged);
}


void RunSplitExample(string folderName)
{
    console.Clear();

    var folderManager = FolderManager.CreateFolderManagerAsProgramSubfolder(folderName);
    var pdfFolder = folderManager.PdfFolderName;

    try
    {
        folderManager.RecreatePFDDocumentsFolder();
    }
    catch (Exception)
    {
        Console.WriteLine($"You seem to already have a PDF file open in a folder {pdfFolder}. Please close all PDF files to process with this example.");
        return;
    }

    var documentsManager = new BigDocument(pdfFolder);
    var merger = new Merger(pdfFolder);

    console.WriteLine("\n\nCreating documents ...\n");
    var document = documentsManager.CreateDocument("document.pdf", PageSize.A5);
    console.WriteLine($" * Document {document} created.");
    DisplayPDFFile(document);

    console.WriteLine("\n\nSplitting document ...\n");
    (var oddPages, var evenPages) = Splitter.Split(document);

    console.WriteLine($"\nDocument split into ... ");
    console.WriteLine($" * Odd  pages: {oddPages} ");
    console.WriteLine($" * Even pages: {evenPages} ");
    DisplayPDFFile(oddPages);
    DisplayPDFFile(evenPages);
}

void RunScaleExample(string folderName)
{
    console.Clear();

    var folderManager = FolderManager.CreateFolderManagerAsProgramSubfolder(folderName);
    var pdfFolder = folderManager.PdfFolderName;

    try
    {
        folderManager.RecreatePFDDocumentsFolder();
    }
    catch (Exception)
    {
        Console.WriteLine($"You seem to already have a PDF file open in a folder {pdfFolder}. Please close all PDF files to process with this example.");
        return;
    }

    var documentsManager = new BigDocument(pdfFolder);
    var resizer = new Resizer(pdfFolder);

    console.WriteLine("\n\nCreating documents ...\n");
    var document = documentsManager.CreateDocument("document.pdf", PageSize.A4);
    console.WriteLine($" * Document {document} created.");
    DisplayPDFFile(document);

    console.WriteLine("\n\nResizing document ...\n");
    var resizeDoc = resizer.ResizeFromA4ToA5(document, "small.pdf");

    console.WriteLine($"\nDocument resized ... ");
    console.WriteLine($" * Resized document: {resizeDoc} ");
    DisplayPDFFile(resizeDoc);
}