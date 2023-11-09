using iText.Kernel.Geom;
using ITextMergingPDFs;
using System.Diagnostics;
using Path = System.IO.Path;

string documentsFolder = CreateDocumentsFolder();

MergeDocumentsOfTheSameSize(documentsFolder);
Wait();

MergeDocumentsOfDifferentPageSizes(documentsFolder);
Wait();

SplitDocument(documentsFolder);
Wait();

ResizeDocument(documentsFolder);
Wait();

Clean(documentsFolder);

void Wait()
{
    Console.WriteLine("\n\n\nPress any key to continue");
    Console.ReadKey();
    Console.Clear();
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

static string CreateDocumentsFolder()
{
    var thisExePath = Environment.ProcessPath;
    var documentsFolder = Path.Combine(Path.GetDirectoryName(thisExePath)!, Guid.NewGuid().ToString());
    Directory.CreateDirectory(documentsFolder);
    return documentsFolder;
}

void MergeDocumentsOfTheSameSize(string documentsFolder)
{
    Console.WriteLine("Merge 3 PDF Documents with the Same Size\n\n");
    var documents = BigDocument.CreateFewDocuments(documentsFolder, "example", 3, PageSize.A4).ToArray();
    foreach (var document in documents)
    {
        Console.WriteLine($" * Document {Path.GetFileName(document)} created.");
        DisplayPDFFile(document);
    }

    Console.WriteLine("\n\nMerging documents ...\n");
    var mergedDocument = Path.Combine(documentsFolder, "merged_a4.pdf");
    Merger.Merge(documents, mergedDocument);

    Console.WriteLine($"\nDocuments merged into {Path.GetFileName(mergedDocument)}");
    DisplayPDFFile(mergedDocument);
}

void MergeDocumentsOfDifferentPageSizes(string documentsFolder)
{
    Console.WriteLine("Merge 3 PDF Documents with Different Page Sizes\n\n");
    var documents = BigDocument.CreateFewDocuments(documentsFolder, "test", 3).ToArray();
    foreach (var document in documents)
    {
        Console.WriteLine($" * Document {Path.GetFileName(document)} created.");
        DisplayPDFFile(document);
    }

    Console.WriteLine("\n\nMerging documents ...\n");
    var mergedDocument = Path.Combine(documentsFolder, "merged_different.pdf");
    Merger.Merge(documents, mergedDocument);

    Console.WriteLine($"\nDocuments merged into {Path.GetFileName(mergedDocument)}");
    DisplayPDFFile(mergedDocument);
}

void SplitDocument(string folderName)
{
    Console.WriteLine("Split document\n\n");

    var documentName = Path.Combine(folderName, "big_document.pdf");
    var document = BigDocument.CreateDocument(documentName, PageSize.A5);
    Console.WriteLine($"Document {Path.GetFileName(document)} created.");
    DisplayPDFFile(document);

    Console.WriteLine("\n\nSplitting document ...\n");
    (var oddPages, var evenPages) = Splitter.Split(document);

    Console.WriteLine($"\nDocument split into ... ");
    Console.WriteLine($"Odd  pages: {Path.GetFileName(oddPages)} ");
    Console.WriteLine($"Even pages: {Path.GetFileName(evenPages)} ");
    DisplayPDFFile(oddPages);
    DisplayPDFFile(evenPages);
}

void ResizeDocument(string folderName)
{
    Console.WriteLine("Resize document\n\n");

    var documentName = Path.Combine(folderName, "Document-A4.pdf");
    var document = BigDocument.CreateDocument(documentName, PageSize.A4);
    Console.WriteLine($"Document {Path.GetFileName(document)} created.");
    DisplayPDFFile(document);

    Console.WriteLine("\n\nResizing document ...\n");
    var newDocumentName = Path.Combine(folderName, "Document-A5.pdf");
    Resizer.ResizeToA5(documentName, newDocumentName);

    Console.WriteLine($"\nDocument resized ... ");
    Console.WriteLine($"Resized document: {Path.GetFileName(newDocumentName)} ");
    DisplayPDFFile(newDocumentName);
}

static void Clean(string documentsFolder)
{
    try
    {
        Directory.Delete(documentsFolder, recursive: true);
    }
    catch
    {
        // if documents are open in PDF viewer, then we cannot delete them
    }
}