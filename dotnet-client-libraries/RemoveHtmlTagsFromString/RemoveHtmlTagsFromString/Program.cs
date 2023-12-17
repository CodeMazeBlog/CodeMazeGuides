using RemoveHtmlTagsFromString;

var htmlString = "<p>This is <b>bold</b> text with <a href='#'>HTML</a> tags. 5&nbsp;&lt;&nbsp;7</p>";
Console.WriteLine("Input: " + htmlString);

var output = HtmlTagRemover.UseRegularExpression(htmlString);
Console.WriteLine("Output Using Reqular Expressions: " + output);

output = HtmlTagRemover.UseHtmlDecode(htmlString);
Console.WriteLine("Output Using HtmlDecode: " + output);

output = HtmlTagRemover.UseHtmlAgilityPack(htmlString);
Console.WriteLine("Output Using HtmlAgilityPack: " + output);

output = HtmlTagRemover.UseAngleSharp(htmlString);
Console.WriteLine("Output Using AngleSharp: " + output);

output = HtmlTagRemover.UseXmlXElement(htmlString);
Console.WriteLine("Output Using XmlXElement: " + output);

output = HtmlTagRemover.ReadHtmlFromFile();
Console.WriteLine("Output ReadHtmlFromFile: " + output);

Console.ReadLine();