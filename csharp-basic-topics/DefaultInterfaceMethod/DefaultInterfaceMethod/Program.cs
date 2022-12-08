using System;

namespace DefaultInterfaceMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create instance of default interface method and you can work with members of the interface
            IDefaultInterface impl = new IDefaultInterfaceImplementation();
            impl.year = 2022;
            impl.ShowMessage();

            //create instance of classes and without having error for ReadWrite()
            SqlServerConnection sql = new SqlServerConnection();
            sql.Open();
            sql.Close();
            OracleConnection oracle = new OracleConnection();
            oracle.Open();
            oracle.Close();

            Console.ReadLine();
        }
    }
}