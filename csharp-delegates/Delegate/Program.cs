using System;
using System.Reflection.Metadata.Ecma335;

namespace DelegateApp
{
    static class GenericDelgates
    {
        public static void Main(string[] args)
        {
            Func<int, int, int, double> ObjSum = (A, B, C) => A + B - C;
            double x = ObjSum.Invoke(10, 10, 10);
            Console.WriteLine(x);

            Action<int, int, int> ObjAction = (A, B, C) => Console.WriteLine(A + B - C);
            ObjAction.Invoke(10, 10, 10);

            Predicate<string> ObjPredicate = (Getlength) =>
            {
                if (Getlength.Length > 10)
                    return true;
                return false;
            };
            bool LengthStatus = ObjPredicate.Invoke("Hii This Is Code Maze");
            Console.WriteLine(LengthStatus);
        }

    }
}
