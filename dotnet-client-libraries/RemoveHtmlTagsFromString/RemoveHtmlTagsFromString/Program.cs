using BenchmarkDotNet.Running;
using RemoveHtmlTagsFromString;

const string HTML_TEXT = "<p>This is <b>bold</b> text with <a href='#'>HTML</a> tags. 5&nbsp;&lt;&nbsp;7</p>";

Console.WriteLine("RegularExpression: {0}", HtmlTagRemover.UseRegularExpression(HTML_TEXT));

Console.WriteLine("HtmlDecode: {0}", HtmlTagRemover.UseHtmlDecode(HTML_TEXT));

Console.WriteLine("HtmlAgilityPack: {0}", HtmlTagRemover.UseHtmlAgilityPack(HTML_TEXT));

Console.WriteLine("AngleSharp: {0}", HtmlTagRemover.UseAngleSharp(HTML_TEXT));

Console.WriteLine("XmlXElement: {0}", HtmlTagRemover.UseXmlXElement(HTML_TEXT));

BenchmarkRunner.Run<RemoveHtmlTagBenchmark>();

Console.ReadLine();