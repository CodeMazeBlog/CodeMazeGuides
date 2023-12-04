public static class StringConstants
{
    public static readonly HashSet<char> InvalidPathChars = new HashSet<char>
    {
        '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a',
        '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011',
        '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018',
        '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f'
    };
    
    public static readonly HashSet<char> InvalidFilenameChars = new HashSet<char>(InvalidPathChars)
    {
        '"', '<', '>', ':', '*', '?', '\\', '/'
    };    
}