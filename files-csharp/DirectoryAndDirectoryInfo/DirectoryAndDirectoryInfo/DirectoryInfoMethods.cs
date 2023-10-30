namespace DirectoryAndDirectoryInfo
{
    public class DirectoryInfoMethods
    {
        public void CreateSubDirectories(DirectoryInfo directory, string subDirectory)
        {
            directory.CreateSubdirectory(subDirectory);
        }

        public void MoveDirectories(DirectoryInfo sourceDirectory, string destDirectory)
        {
            sourceDirectory.MoveTo(destDirectory);
        }

        public void EnumerateDirectories(DirectoryInfo directoryInfo)
        {
            foreach (var subdirectory in directoryInfo.EnumerateDirectories())
            {
                Console.WriteLine(subdirectory.FullName);
            }
        }
    }
}
