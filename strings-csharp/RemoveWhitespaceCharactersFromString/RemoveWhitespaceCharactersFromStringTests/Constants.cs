namespace RemoveWhitespaceCharactersFromStringTests;

internal static class Constants
{
    public static readonly char[] WhiteSpaceCharacters =
    {
        '\u0009', // Tab
        '\u000A', // Linefeed
        '\u000B', // VerticalTab
        '\u000C', // FormFeed
        '\u000D', // CarriageReturn
        '\u0020', // Space
        '\u0085', // NextLine
        '\u00A0', // NoBreakSpace
        '\u1680', // OghamSpaceMark
        '\u2000', // EnQuad
        '\u2001', // EmQuad
        '\u2002', // EnSpace
        '\u2003', // EmSpace
        '\u2004', // ThreePerEmSpace
        '\u2005', // FourPerEmSpace
        '\u2006', // SixPerEmSpace
        '\u2007', // FigureSpace
        '\u2008', // PunctuationSpace
        '\u2009', // ThinSpace
        '\u200A', // HairSpace
        '\u2028', // LineSeparator
        '\u2029', // ParagraphSeparator
        '\u202F', // NarrowNoBreakSpace
        '\u205F', // MediumMathematicalSpace
        '\u3000' // IdeoGraphicSpace
    };
}