// See https://aka.ms/new-console-template for more information
using StringProcessSolution;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;

class Program
{
    static void Main(string[] args)
    {


        //int myVal = -5;
        //int age = 5;
        //age = age + 1;      
        //age =IncrementAge(age);
        //Console.WriteLine(age);//
        //                       //Console.WriteLine(age);//

        string ageString = "345";

        int newInt = Convert.ToInt32(ageString);

        Console.WriteLine(newInt);
        Console.ReadLine();

        //Sum(4, 5);
        MathClass mathClass = new MathClass();
        mathClass.SumMath(1, 2);
        Console.WriteLine("Hello, World!");
        int number = 4;
        //implicit
        //explicit

        long longNum = number;//convert
        int longIn = (int)longNum;//explicit cast
                                  //Cast convert;
                                  //1-9 edelerden cut olanlari ekrana yazdir,tek olanlari uzerine bir gel ekrana yazdir.
        //for (int i = 1; i <= 9; i++)
        //{
        //    if (i > 3)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    else { Console.WriteLine("error"); }
            

        //}
        int ternaryNumber = 4;
        //?:

        int i=ternaryNumber>4?ternaryNumber:0;
        Console.ReadLine();
        if (number == 0)
        {
            Console.WriteLine(number);
        }
        for (int i = 0; i < 5; i++)
        {
            number--;
            number = number - 1;
        }
        for (int i = 0; i < 6; i++)
        {
            Guid newguid = Guid.NewGuid();
            Console.WriteLine(newguid);

        }
        Random rnd = new Random();

        for (int i = 0; i < 6; i++)
        {

            Console.WriteLine(rnd.Next(1, 5));

        }
        Console.ReadLine();


        string word = "dg";
        //default

        string myWord = "dfsdfjl";
        int numbers = 132;
        //foreach (var item in myWord)
        //{
        //    Console.WriteLine(item);
        //}
        //word=word + "gr";
        char firstChar = 'd';
        int myValue = 4;
        myValue++;
        string newWord = "My age is " + " " + myValue;
        //string interpolation
        string newWord1 = $"My age is {myValue}";
        //string formatting,
        string newFormat = String.Format("My age is {0}{1}", myValue, 2);
        //Console.WriteLine(newWord);
        //Console.WriteLine(newWord1);
        //Console.WriteLine(newFormat);
        //string defaultcString = default;
        //Console.WriteLine($"defaultcString {defaultcString}");
        //int defaultInt = default;
        //Console.WriteLine($"defaultInt {defaultInt}");
        //bool defaultBool = default;
        //Console.WriteLine($"defaultBool {defaultBool}");
        //char defaultChar = default;
        //Console.WriteLine($"defaultChar {defaultChar}");
        //decimal defaultDecimal = default;
        //Console.WriteLine($"defaultDecimal {defaultDecimal}");
        //float defaultFloat = default;
        //Console.WriteLine($"defaultFloat {defaultFloat}");
        //double defaultDouble = default;
        //Console.WriteLine($"defaultDouble {defaultDouble}");
        //Console.ReadLine();



    }
    public void Sum(int firstNum, int secondNum)
    {
        Console.Write ( firstNum + secondNum);

    }
    static int IncrementAge(int age)
    {
        age = age+1;
        return age;
    }
}



