public class TextFileManager : IDisposable
{
    private bool _desposed;
    private readonly string _rootDirectory;
    private readonly FileSystemWatcher _fileSystemWatcher;

    public TextFileManager(string rootDirectory)
    {
        _rootDirectory = rootDirectory;
        _fileSystemWatcher = new FileSystemWatcher(rootDirectory);

        ConfigureFilters();
        ConfigureEvents();
    }

    public void Create(string fileName, IEnumerable<string> content)
    {
        var path = AbsolutePath(fileName);
        if (File.Exists(path))
            throw new Exception($"File With the same name exists: {fileName}");
        
        File.WriteAllLines(path, content);
    }

    public void Update(string fileName, IEnumerable<string> newContent)
    {
        var path = AbsolutePath(fileName);
        if (!File.Exists(path))
            throw new FileNotFoundException(path);
        
        File.WriteAllLines(path, newContent);
    }

    public void Delete(string fileName)
    {
        var path = AbsolutePath(fileName);
        if(!File.Exists(path))
            throw new FileNotFoundException(path);
            
        File.Delete(path);
    }

    public void Rename(string oldName, string newName)
    {
        var oldPath = AbsolutePath(oldName);
        var newPath = AbsolutePath(newName);
        if(!File.Exists(oldPath))
            throw new FileNotFoundException(oldPath);
        
        File.Move(oldPath, newPath);
    }

    private void ConfigureFilters()
    {
        _fileSystemWatcher.Filter = "*.txt";
        _fileSystemWatcher.IncludeSubdirectories = true;
        _fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
                                    | NotifyFilters.CreationTime
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.FileName
                                    | NotifyFilters.LastAccess
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.Security
                                    | NotifyFilters.Size;
    }

    private void ConfigureEvents()
    {
        _fileSystemWatcher.Created += HandleCreated;
        _fileSystemWatcher.Deleted += HandleDeleted;
        _fileSystemWatcher.Renamed += HandleRenamed;
        _fileSystemWatcher.Error += HandleError;
        _fileSystemWatcher.Changed += HandleChanged;

        _fileSystemWatcher.EnableRaisingEvents = true;
    }

    private void HandleChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Change: {Enum.GetName(e.ChangeType)} {e.FullPath}");
    }

    private void HandleError(object sender, ErrorEventArgs e)
    {
        Console.WriteLine($"Error: {e.GetException().Message}");
    }

    private void HandleRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Rename: {e.OldName} => {e.Name}");
    }

    private void HandleDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Delete: {e.FullPath}");
    }

    private void HandleCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Create: {e.FullPath}");
    }

    private string AbsolutePath(string fileName) => Path.Combine(_rootDirectory, fileName);

    ~TextFileManager()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(true);
    }

    public virtual void Dispose(bool disposing)
    {
        if(_desposed)
            return;
        
        if(disposing)
        {
            _fileSystemWatcher.Dispose();
        }

        _desposed = true;
    }
}