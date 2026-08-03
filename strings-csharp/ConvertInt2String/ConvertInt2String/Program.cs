using ConvertInt2String;
using System.Text;

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

Console.WriteLine(Benchmark.Run(luckyNumber, 200000));
Console.WriteLine(Benchmark.Run(luckyNumber, 2000000));

Console.ReadLine();




