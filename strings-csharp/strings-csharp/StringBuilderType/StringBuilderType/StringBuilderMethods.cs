namespace StringBuilderType;
using System.Text;

public class StringBuilderMethods
{
    public void Instantiate()
    {
        var value = "How to instantiate a StringBuilder";
        var index = value.IndexOf("H") + 7;
        var capacity = 30;
        var maxCapacity = 100;

        // Instantiate a StringBuilder 
        var sb = new StringBuilder();

        // Instantiate a StringBuilder and define a capacity
        sb = new StringBuilder(capacity);

        // Instantiate a StringBuilder and define a capacity and maximum capacity
        sb = new StringBuilder(capacity, maxCapacity);

        // Instantiate a StringBuilder from a string.
        sb = new StringBuilder(value);

        // Instantiate a StringBuilder from string  with a default capacity.  
        sb = new StringBuilder(value, capacity);

        // Instantiate a StringBuilder from substring and define a capacity.  
        sb = new StringBuilder(value, index, value.Length - index, capacity);
    }

    public StringBuilder Append()
    {
        var sb = new StringBuilder("Welcome, ");
        sb.Append("I hope you learned something.");

        return sb;
    }

    public StringBuilder Append(string basetext, int length = 1000)
    {
        var sb = new StringBuilder(length);
        // Append some text.
        foreach (var item in basetext)
        {
            sb.Append(item);
        }

        return sb;
    }

    public StringBuilder AppendLine()
    {
        var stringBuilder = new StringBuilder("Welcome, I hope you learned something.");
        stringBuilder.AppendLine();

        return stringBuilder;
    }

    public StringBuilder AppendLine(string basetext)
    {
        var sb = new StringBuilder();
        sb.Append(basetext);
        sb.AppendLine();

        return sb;
    }

    public StringBuilder AppendFormat(string basetext, string format)
    {
        var sb = new StringBuilder();
        sb.AppendFormat(format, basetext);

        return sb;
    }

    public StringBuilder AppendFormat()
    {
        var stringBuilder = new StringBuilder("Welcome, ");
        stringBuilder.AppendFormat("to register for the full class, you need to pay a sum of {0:C}", 157);

        return stringBuilder;
    }

    public StringBuilder Insert()
    {
        var stringBuilder = new StringBuilder("Hi");
        stringBuilder.Insert(2, ", welcome to our blog");

        return stringBuilder;
    }

    public StringBuilder Insert(string basetext, string textToAppend, int index = 0)
    {
        var sb = new StringBuilder(basetext);
        sb.Insert(index, textToAppend);

        return sb;
    }

    public StringBuilder Remove(string text, string textToRemove)
    {
        var sb = new StringBuilder(text);
        var pos = sb.ToString().IndexOf(textToRemove);

        if (pos >= 0)
        {
            sb.Remove(pos, textToRemove.Length);
        }

        return sb;
    }

    public StringBuilder Remove()
    {
        var stringBuilder = new StringBuilder("Welcome, I hope you learned something today");
        stringBuilder.Remove(0, 8);

        return stringBuilder;
    }

    public StringBuilder Replace()
    {
        var stringBuilder = new StringBuilder("Welcome, I hope you learned something");
        stringBuilder.Replace("learned", "gained");

        return stringBuilder;
    }

    public StringBuilder Replace(string text, string stringToReplace, string stringToReplaceWith)
    {
        var sb = new StringBuilder(text);
        sb.Replace(stringToReplace, stringToReplaceWith);

        return sb;
    }

    public int Clear()
    {
        var stringBuilder = new StringBuilder("Welcome, I hope you learned something");
        stringBuilder.Clear();

        return stringBuilder.Length;
    }

    public int Clear(StringBuilder sb)
    {
        sb.Clear();

        return sb.Length;
    }

    public string ConvertToString(StringBuilder stringBuilder)
    {
        return stringBuilder.ToString();
    }

    public string ConvertToString()
    {
        var stringBuilder = new StringBuilder("Adding Text to a StringBuilder.");
        var stringOutcome = stringBuilder.ToString();

        return stringOutcome;
    }
}

