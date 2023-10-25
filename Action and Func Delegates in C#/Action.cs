Action<string, int> Message_print = (content, count) =>
{
    for (int i = 0; i < count; i++)
    {
        Console.WriteLine(content);
    }
};

Message_print("Hello_word, Action!", 6);