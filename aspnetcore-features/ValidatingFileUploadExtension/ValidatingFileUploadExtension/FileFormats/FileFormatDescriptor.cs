using ValidatingFileUploadExtension;

public abstract class FileFormatDescriptor
{
    protected FileFormatDescriptor()
    {
        Initialize();
        MaxMagicNumberLength = MagicNumbers.Max(m => m.Length);
    }

    protected abstract void Initialize();

    protected HashSet<string> Extensions { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    protected List<byte[]> MagicNumbers { get; } = [];
    protected int MaxMagicNumberLength { get; }
    protected string TypeName { get; set; }

    public bool IsIncludedExtention(string extention) => Extensions.Contains(extention);

    public Result Validate(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        Span<byte> initialBytes = stackalloc byte[MaxMagicNumberLength];
        int Readbytes = stream.Read(initialBytes);

        foreach (var magicNumber in MagicNumbers)
        {
            if (initialBytes[..magicNumber.Length].SequenceCompareTo(magicNumber) == 0)
            {
                return new Result(true, Status.GENUINE, $"{Status.GENUINE} {TypeName}");
            }
        }

        return new Result(false, Status.FAKE, $"{Status.FAKE} {TypeName}!");
    }
}