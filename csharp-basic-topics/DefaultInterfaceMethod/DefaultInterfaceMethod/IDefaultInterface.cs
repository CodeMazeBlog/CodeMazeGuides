using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultInterfaceMethod
{
    public interface IDefaultInterface
    {
        int year { get; set; }
        private static string message = "Welcome to FIFA World Cup ";
        public string FullMessage()
        {
            return message + year;
        }
        public void ShowMessage()
        {
            Console.WriteLine(FullMessage());
        }
    }
}
