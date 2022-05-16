namespace CopyToClipboardBlazor;

public interface IClipboardService
{
    Task CopyToClipboard(string text);
}