namespace RenameFilesWithCSharp;

public static class FolderRenameService
{
    public static void RenameFolder(string oldFolder, string newFolder)
    {
        Directory.Move(oldFolder, newFolder);
    }

    public static void ExecuteRenameFolder()
    {
        var parentPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        var oldFolder = Path.Combine(parentPath, "Invoices2025");
        Directory.CreateDirectory(Path.Combine(oldFolder, "Q1"));
        File.Create(Path.Combine(oldFolder, "Q1", "invoice-001.pdf")).Dispose();

        var newFolder = Path.Combine(parentPath, "Invoices-2025");

        RenameFolder(oldFolder, newFolder);

        Console.WriteLine($"Renamed {Path.GetFileName(oldFolder)} to {Path.GetFileName(newFolder)}");
        Console.WriteLine($"Invoice moved along: {File.Exists(Path.Combine(newFolder, "Q1", "invoice-001.pdf"))}");

        Directory.Delete(parentPath, true);
    }
}
