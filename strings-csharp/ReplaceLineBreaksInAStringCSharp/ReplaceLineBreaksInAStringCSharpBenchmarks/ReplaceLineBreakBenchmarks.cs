using BenchmarkDotNet.Attributes;
using ReplaceLineBreaksInAStringCSharp;

namespace ReplaceLineBreaksInAStringCSharpBenchmarks;

[MemoryDiagnoser]
public class ReplaceLineBreakBenchmarks
{
    private const string ShortText = "This is a line.\rThis is another line.";

    private const string MixedText =
        "The quick brown fox jumps over the lazy dog.\r\n" +
        "Pack my box with five dozen liquor jugs.\n" +
        "How vexingly quick daft zebras jump.\r" +
        "Sphinx of black quartz, judge my vow.\r\n" +
        "Jackdaws love my big sphinx of quartz.\n" +
        "The five boxing wizards jump quickly.\r" +
        "Bright vixens jump; dozy fowl quack.\r\n" +
        "Quick zephyrs blow, vexing daft Jim.\n" +
        "Two driven jocks help fax my big quiz.\r" +
        "Waltz, bad nymph, for quick jigs vex.\r\n" +
        "Glib jocks quiz nymph to vex dwarf.\n" +
        "Fickle jinx bog dwarves spy math quiz.\r";

    [Params("Short", "Mixed")]
    public string Input { get; set; } = "Short";

    private string _text = ShortText;

    [GlobalSetup]
    public void GlobalSetup() => _text = Input == "Short" ? ShortText : MixedText;

    [Benchmark]
    public string StringReplace() =>
        ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceMethod(_text);

    [Benchmark]
    public string StringReplaceLineEndings() =>
        ReplaceLineBreak.ReplaceLineBreaksUsingTheStringReplaceLineEndingsMethod(_text);

    [Benchmark]
    public string RegexReplace() =>
        ReplaceLineBreak.ReplaceLineBreaksUsingTheRegularExpressionReplaceMethod(_text);
}
