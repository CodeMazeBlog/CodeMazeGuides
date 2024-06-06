string txt1 = "unbelievable";
string txt2 = "complicated";
string txt3 = "interesting";
string txt4 = "temporary";
string txt5 = "extraordinary";
string txt6 = "proportional";

List<string> txts = [txt1, txt2, txt3, txt4, txt5, txt6];

Thread thread = Thread.CurrentThread;
thread.Name = "Main";

foreach (var txt in txts)
{
    Random rnd = new();
    int length = rnd.Next(3, txt.Length); 
    
    Console.WriteLine(PrintPart(txt, length));
}

static string PrintPart(string txt, int charsCount)
{
    return txt[..charsCount];
}
