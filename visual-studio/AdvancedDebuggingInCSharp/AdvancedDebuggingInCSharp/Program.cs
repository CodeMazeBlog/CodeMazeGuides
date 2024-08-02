var txt1 = "unbelievable";
var txt2 = "complicated";
var txt3 = "interesting";
var txt4 = "temporary";
var txt5 = "extraordinary";
var txt6 = "proportional";

List<string> txts = [txt1, txt2, txt3, txt4, txt5, txt6];

Thread thread = Thread.CurrentThread;
thread.Name = "Main";
Random rnd = new();

foreach (var txt in txts)
{    
    int length = rnd.Next(3, txt.Length);
    Console.WriteLine(PrintPart(txt, length));
}

static string PrintPart(string txt, int charsCount)
{
    return txt[..charsCount];
}

public partial class Program { }