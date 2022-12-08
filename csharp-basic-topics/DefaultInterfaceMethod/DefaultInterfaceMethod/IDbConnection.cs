using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethod
{
    //existing interface
    interface IDbConnection
    {
        void Open();
        void Close();
        // default interface method or adding new method with body 
        void ReadWrite() => Console.WriteLine("Read & Write Operations");

    }
    //existing class code doesn't break on addition of ReadWrite() method in IDbConnection
    public class SqlServerConnection : IDbConnection
    {
        public void Open() => Console.WriteLine("SQL Server Connection opened.");
        public void Close() => Console.WriteLine("SQL Server Connection Closed.");

    }
    //existing class code doesn't break on addition of ReadWrite() method in IDbConnection
    public class OracleConnection : IDbConnection
    {
        public void Open() => Console.WriteLine("Oracle Connection opened.");
        public void Close() => Console.WriteLine("Oracle Connection Closed.");

    }

}
