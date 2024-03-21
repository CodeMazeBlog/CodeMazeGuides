using ValidatingFileUploadExtension;

public static class FileValidator
{   
    private static readonly List<FileFormatDescriptor> AllowedFormats = [new Image(), new Pdf()];

    public static Result Validate(IFormFile file)
    {
        var fileExtension = Path.GetExtension(file.FileName);
        var targetType = AllowedFormats.FirstOrDefault(x => x.IsIncludedExtention(fileExtension));

        if (targetType is null)
        {
            return new Result(false, Status.NOT_SUPPORTED, $"{Status.NOT_SUPPORTED}");
        }

        return targetType.Validate(file);
    }
}