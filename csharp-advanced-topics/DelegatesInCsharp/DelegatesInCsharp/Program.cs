using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesInCsharp
{

	class Program
	{
        private static void Main(string[] args)
        {
            #region Delegates
            DelegateOfMethod delProduct = new DelegateOfMethod(Product);
            Console.WriteLine(delProduct(5).ToString());

            int returnedFromMethod = MethodUsesDelegate(delProduct, 5);
            Console.WriteLine(returnedFromMethod.ToString());

            int anotherMethod = MethodUsesDelegate(new DelegateOfMethod(Sum), 5);
            Console.WriteLine(anotherMethod.ToString());
            #endregion

            #region Action
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            numbers.ForEach(x => Console.WriteLine(x.ToString()));
            numbers.ForEach(x => Console.WriteLine((x * x).ToString()));
            #endregion

            #region Func
            Func<int, int, int> del = (x, y) => { return (x + y); };
            Console.WriteLine(del(1, 2).ToString());
            del = (x, y) => { return (x * y); };
            Console.WriteLine(del(1, 2).ToString());

            //on Linq
            var evenNumbers = numbers.Where(x => x % 2 == 0);
            evenNumbers.ToList().ForEach(x => Console.WriteLine(x.ToString()));

            var oddNumbers = numbers.Where(x => x % 2 == 1);
            oddNumbers.ToList().ForEach(x => Console.WriteLine(x.ToString()));
            #endregion

        }
        #region delegate example methods
        delegate int DelegateOfMethod(int x);
        private static int Product(int x) => x * x;
        private static int MethodUsesDelegate(DelegateOfMethod del, int x) => del(x);

        //another method
        private static int Sum(int x) => x + x;
        #endregion

    }
}
