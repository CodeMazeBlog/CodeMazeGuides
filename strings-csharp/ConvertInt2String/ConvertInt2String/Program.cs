using System.Text;

int luckyNumber = 3;
Console.WriteLine(luckyNumber);
Console.WriteLine(luckyNumber.ToString());

Console.WriteLine(Convert.ToString(luckyNumber));

Console.WriteLine(string.Format("{0}", luckyNumber));

Console.WriteLine($"{luckyNumber}");

Console.WriteLine(string.Concat(string.Empty, luckyNumber));
Console.WriteLine(string.Join(string.Empty, luckyNumber));
Console.WriteLine(string.Empty + luckyNumber);
Console.WriteLine(luckyNumber + luckyNumber + string.Empty + luckyNumber + luckyNumber);

Console.WriteLine(new StringBuilder().Append(luckyNumber).ToString());