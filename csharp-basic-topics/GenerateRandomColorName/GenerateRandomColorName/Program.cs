using System.Drawing;
using GenerateRandomColorName;

KnownColorGenerator colorGenerator = new KnownColorGenerator();
Color randomColor = colorGenerator.GetRandomKnownColor();

Console.WriteLine("Random Known Color: " + randomColor.Name);