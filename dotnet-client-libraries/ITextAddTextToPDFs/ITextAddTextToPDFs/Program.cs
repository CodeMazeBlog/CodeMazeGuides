using iText.Kernel.Colors;
using ITextAddTextToPDFs;
using System.Diagnostics;

Console.WriteLine("Add text to each page with BasicTextAdder class\n\n");
BasicCopyPDFAndAddText("text");
BasicCopyPDFAndAddText("picture");
Wait();

Console.WriteLine("Add text to each page with TextAdder class\n\n");
CopyPDFAndAddText("text");
CopyPDFAndAddText("picture");
Wait();

Console.WriteLine("Add rotated text in the middle of the page\n\n");
CopyPDFAndAddRotatedText("text");
CopyPDFAndAddRotatedText("picture");
Wait();

Console.WriteLine("Add text as watermark\n\n");
CopyPDFAndAddTextAsWatermark("text");
CopyPDFAndAddTextAsWatermark("picture");
Wait();

Console.WriteLine("Add headers\n\n");
CopyPDFAndAddHeader("text");
CopyPDFAndAddHeader("picture");
Wait();

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

string GetExistingFileByType(string documentType)
{
    return SampleDocument.Get(
        string.Equals(documentType, "picture", StringComparison.OrdinalIgnoreCase)
        ? "PictureDocument.pdf"
        : "TextDocument.pdf");
}

void BasicCopyPDFAndAddText(string documentType)
{
    var newFileName = $"test1-{documentType}.pdf";
    var newFile = SampleDocument.CreateFile(newFileName);

    BasicTextAdder.Add(GetExistingFileByType(documentType), newFile, "This is a new text");

    DisplayPDFFile(newFile);
}

void CopyPDFAndAddText(string documentType)
{
    var newFileName = $"test2-{documentType}.pdf";
    var newFile = SampleDocument.CreateFile(newFileName);

    var copier = new TextAdder(GetExistingFileByType(documentType), newFile);
    copier.Add("This is new text");

    DisplayPDFFile(newFile);
}

void CopyPDFAndAddRotatedText(string documentType)
{
    var newFileName = $"test3-{documentType}.pdf";
    var newFile = SampleDocument.CreateFile(newFileName);

    var copier = new TextAdder(GetExistingFileByType(documentType), newFile);
    copier.AddCenterText("This is a Copy", 80,
        UnitConverter.degree2radian(45), ColorConstants.GREEN);

    DisplayPDFFile(newFile);
}

void CopyPDFAndAddTextAsWatermark(string type)
{
    var newFileName = $"test4-{type}.pdf";
    var newFile = SampleDocument.CreateFile(newFileName);

    var copier = new TextAdder(GetExistingFileByType(type), newFile);
    copier.AddWatermark("This is a watermarked copy", 80,
        UnitConverter.degree2radian(55), ColorConstants.GREEN);

    DisplayPDFFile(newFile);
}

void CopyPDFAndAddHeader(string documentType)
{
    var newFileName = $"test5-{documentType}.pdf";
    var newFile = SampleDocument.CreateFile(newFileName);

    var copier = new TextAdder(GetExistingFileByType(documentType), newFile);
    copier.AddHeaders();

    DisplayPDFFile(newFile);
}