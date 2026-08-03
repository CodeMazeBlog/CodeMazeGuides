using System.Globalization;
using StringInterpolationDemo;

Console.WriteLine(BasicStrings.SimpleString("Joe", "bun"));
Console.WriteLine(BasicStrings.ThisManyBottlesOfBeerOnTheWall(99));
Console.WriteLine(BasicStrings.DisplayTableCell(150, true));
Console.WriteLine(BasicStrings.ConstantString);

Console.WriteLine(BasicStrings.NewLinesInExpression(1));
Console.WriteLine(BasicStrings.NewLinesInExpression(2));
Console.WriteLine(BasicStrings.NewLinesInExpression(3));
Console.WriteLine(BasicStrings.NewLinesInExpression(4));

Console.WriteLine(EscapedStrings.SimpleEscapedCurlyBraces());

Console.WriteLine(EscapedStrings.ThisManyBottlesOfBeerOnTheWall(2));
Console.WriteLine(EscapedStrings.ThisManyBottlesOfBeerOnTheWall(1));

Console.WriteLine(VerbatimAndRawStrings.SimpleVerbatimString("profilePhoto.jpg"));
Console.WriteLine(VerbatimAndRawStrings.AnotherVerbatimString("profilePhoto.jpg"));
Console.WriteLine(VerbatimAndRawStrings.SimpleRawString());
Console.WriteLine(VerbatimAndRawStrings.EscapedRawString());

DateTime date = new(2022, 11, 12, 13, 14, 15, DateTimeKind.Utc);
IFormattable message = $"Date is: {date}";

Console.WriteLine(message.ToString(null, CultureInfo.GetCultureInfo("en-US")));
Console.WriteLine(message.ToString(null, CultureInfo.GetCultureInfo("sv-SE")));

FormattableString anotherMessage = $"Due date is: {date:D}";

Console.WriteLine(anotherMessage.ToString(CultureInfo.GetCultureInfo("en-US")));
Console.WriteLine(anotherMessage.ToString(CultureInfo.GetCultureInfo("sv-SE")));
Console.WriteLine(FormattableString.Invariant(anotherMessage));
Console.WriteLine(FormattableString.CurrentCulture(anotherMessage));
