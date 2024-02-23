#nullable disable
namespace ValidatingFileUploadExtension.FileFormats
{
    public abstract class FileFormatDescriptor
    {
        protected FileFormatDescriptor()
        {
            Initialize();
        }
        protected abstract void Initialize();

        protected List<string> Extensions { get; set; } = [];
        protected List<byte[]> MagicNumbers { get; set; } = [];
        protected string TypeName { get; set; }
        public bool IsIncludedExtention(string extention) => Extensions.Contains(extention);
        public Result Validate(IFormFile file)
        {
            var toReadBytesCount = MagicNumbers.Max(m => m.Length);
            using (var stream = file.OpenReadStream())
            {
                stream.Position = 0;
                var initialBytes = new BinaryReader(stream).ReadBytes(toReadBytesCount);
                foreach (var magicNumber in MagicNumbers)
                {
                    if (initialBytes.Take(magicNumber.Length).SequenceEqual(magicNumber))
                    {
                        return new Result(true, Status.GENUINE, $"{Status.GENUINE} {TypeName}");
                    }
                }
                return new Result(false, Status.FAKE, $"{Status.FAKE} {TypeName}!");
            }
        }
    }
}
