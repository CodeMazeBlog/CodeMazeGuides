namespace DirectoryAndDirectoryInfo
{
    public class DirectoryInfoMethods
    {
        public DirectoryInfo CreateSubDirectories(DirectoryInfo directory, string subDirectory)
        {
            return directory.CreateSubdirectory(subDirectory);
        }

        public void MoveDirectories(DirectoryInfo sourceDirectory, string destDirectory)
        {
            sourceDirectory.MoveTo(destDirectory);
        }

        public void EnumerateDirectories(DirectoryInfo directoryInfo)
        {
            foreach (var subdirectory in directoryInfo.EnumerateDirectories())
            {
                Console.WriteLine(subdirectory.Name);
            }
        }
    }
}
