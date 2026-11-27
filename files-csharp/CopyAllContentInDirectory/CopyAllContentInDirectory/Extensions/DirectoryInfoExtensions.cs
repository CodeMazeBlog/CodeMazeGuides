namespace CopyAllContentInDirectory.Extensions;

public static class DirectoryInfoExtensions
{
    public static void DeepCopy(this DirectoryInfo directory, string destinationDir, bool overwriteFiles)
    {
        foreach (string dir in Directory.GetDirectories(directory.FullName, "*", SearchOption.AllDirectories))
        {
            string dirToCreate = Path.Join(destinationDir, Path.GetRelativePath(directory.FullName, dir));
            Directory.CreateDirectory(dirToCreate);
        }

        Directory.CreateDirectory(destinationDir);

        foreach (string newPath in Directory.GetFiles(directory.FullName, "*.*", SearchOption.AllDirectories))
        {
            string newFile = Path.Join(destinationDir, Path.GetRelativePath(directory.FullName, newPath));
            File.Copy(newPath, newFile, overwriteFiles);
        }
    }
}
