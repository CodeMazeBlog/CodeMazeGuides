using System.Drawing;
using GenerateRandomColorName;

Color randomColor = KnownColorGenerator.GetRandomKnownColor();

Console.WriteLine("Random Known Color: " + randomColor.Name);