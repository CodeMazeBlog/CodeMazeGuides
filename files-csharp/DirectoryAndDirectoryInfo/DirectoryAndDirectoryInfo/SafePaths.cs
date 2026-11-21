namespace DirectoryAndDirectoryInfo
{
    public static class SafePaths
    {
        public static string? ResolveInside(string rootDirectory, string userInput)
        {
            var root = Path.TrimEndingDirectorySeparator(Path.GetFullPath(rootDirectory))
                + Path.DirectorySeparatorChar;
            var fullPath = Path.GetFullPath(Path.Join(root, userInput));

            return fullPath.StartsWith(root, StringComparison.Ordinal) ? fullPath : null;
        }
    }
}
