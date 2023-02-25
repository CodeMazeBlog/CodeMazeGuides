using System.Diagnostics.SymbolStore;
using System.IO.Compression;

namespace Zip_files_in_NET
{
  public class ReadZipStructure
  {
    public void WriteName(string zipFileName) =>
      ExecuteWrite(zipFileName, (entry) => entry.Name);

    public void WriteFullName(string zipFileName) =>
      ExecuteWrite(zipFileName, (entry) => entry.FullName);

    private void ExecuteWrite(string zipFileName, Func<ZipArchiveEntry, string> element)
    {
      int counter = 0;

      var zipFile = ZipFile.OpenRead(zipFileName);
      foreach (var entry in zipFile.Entries)
        Console.WriteLine($"{++counter,3}: {element(entry)}");

      Console.WriteLine("\n----------\n");
    }
  }
}
