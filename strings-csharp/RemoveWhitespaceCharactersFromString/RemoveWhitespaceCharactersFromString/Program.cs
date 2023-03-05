using System.Text;
using System.Text.RegularExpressions;

//regex
{
    var source = " \t hello worl d";
    var result = Regex.Replace(source, @"\s+", String.Empty);
    Console.WriteLine(result); // prints 'helloworld'
}

//linq
{
    var source = "hello \t world\r\n123"; 
    var result = string.Concat(source.Where(c => !char.IsWhiteSpace(c))); 
    Console.WriteLine(result); //prints 'helloworld123'
}

//replace
{
    var source = " Hello World!"; 
    var result = source.Replace(" ", string.Empty); 
    Console.WriteLine(result); // prints 'HelloWorld!'
}

//trim
{
    var source = " \t John Doe "; 
    var result = source.Trim(); 
    Console.WriteLine(result); //prints 'John Doe'
}

//string builder
{
    static string RemoveWhitespaces(string str) 
    { 
        var builder = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++) 
        { 
            char c = str[i]; 
            if (!char.IsWhiteSpace(c))
                builder.Append(c); 
        } 
        return builder.ToString(); 
    }

    var input = " Hello World! \r\n"; 
    var stringWithoutWhitespaces = RemoveWhitespaces(input); 
    Console.WriteLine(stringWithoutWhitespaces); //prints "HelloWorld!"

}