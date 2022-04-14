using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class MyClass
    {
        public string MethodOne(string message)
        {
            return $"The message is: {message}";
        }

        public string MethodWithDelegateParam(MyFirstDelegate delParam)
        {
            var result = delParam("Hi There");
            return result;
        }

        public string MethodTwo(string firstName, string lastName) 
        {
            var fullName = $"{firstName} {lastName}";
            return fullName;
        }

        public static string name;
        public void MethodThree(string firstName, string lastName)
        {
            name = $"{firstName} {lastName}";
        }
    }
}
