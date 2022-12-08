using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethod
{
    //base interface
    interface ITransaction
    {
        void Transaction() => Console.WriteLine("Base Method");
    }
    //inherited interface
    interface ICredit : ITransaction
    {
        void ITransaction.Transaction()
        {
            Console.WriteLine("Your account has been credited!");
        }
    }
    //inherited interface
    interface IDebit : ITransaction
    {
        void ITransaction.Transaction()
        {
            Console.WriteLine("Your account has been debited!");
        }
    }
    // multiple inheritance of interfaces with Transaction() method in each interface
    public class AllTransaction : ICredit, IDebit
    {
        // defining the implementation here avoids diamond problem
        public void Transaction()
        {
            Console.WriteLine("Your account has been credited and debited!");
        }
    }


}
