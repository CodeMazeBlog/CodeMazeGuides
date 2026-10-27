using System.Globalization;
using System.Text;
using BenchmarkDotNet.Running;
using ConvertInt2String;

var luckyNumber = 3;

Console.WriteLine(luckyNumber);
Console.WriteLine(luckyNumber.ToString());
Console.WriteLine(Convert.ToString(luckyNumber));
Console.WriteLine(string.Format("This is our number {0}", luckyNumber));
Console.WriteLine($"This is our number {luckyNumber}");
Console.WriteLine(string.Concat(string.Empty, luckyNumber));
Console.WriteLine(string.Join(string.Empty, luckyNumber));
Console.WriteLine(string.Empty + luckyNumber);
Console.WriteLine(luckyNumber + luckyNumber + string.Empty + luckyNumber + luckyNumber);
Console.WriteLine(new StringBuilder().Append(luckyNumber).ToString());

var negativeNumber = -5;
var swedish = CultureInfo.GetCultureInfo("sv-SE");

Console.WriteLine(negativeNumber.ToString(swedish) == "-5");
Console.WriteLine(negativeNumber.ToString(CultureInfo.InvariantCulture) == "-5");

BenchmarkSwitcher.FromAssembly(typeof(IntToStringBenchmarks).Assembly).Run(args);
