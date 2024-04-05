public class Pdf : FileFormatDescriptor
{
    protected override void Initialize()
    {
        TypeName = "PDF FILE";
        Extensions.Add(".pdf");
        MagicNumbers.Add([0x25, 0x50, 0x44, 0x46]);
    }
}