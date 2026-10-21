char[] charArray = ['c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e'];

var convertedToString = new string(charArray);

Console.WriteLine(convertedToString);

var partOfArray = new string(charArray, 0, 4);

Console.WriteLine(partOfArray);

var joinedToString = string.Join("", charArray);

Console.WriteLine(joinedToString);

var withDashes = string.Join("-", charArray);

Console.WriteLine(withDashes);

var concatedToString = string.Concat(charArray);

Console.WriteLine(concatedToString);

char letter = 'c';

var fromChar = letter.ToString();

Console.WriteLine(fromChar);
