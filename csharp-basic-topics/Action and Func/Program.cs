// This is for Action delegate.
Action<string, int> Messageprint = (content, count) =>
{
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(content);
    }
};

Messageprint("Hello_word, Action!", 6);



// This is for Fun delegate.
Func<int, int, int> Sub = (a, b) => a - b;

int res = Sub(15, 13);
Console.WriteLine("15 - 13 = " + res);
