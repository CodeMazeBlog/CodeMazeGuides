using System;

namespace CodeMaze {
    class ActionDelegate{
        public static void WriteStr(string str){
            Console.WriteLine("Output : "+str);
        }
        static void Main(string[] args){
            Action<string> StringWriter = WriteStr; // Intantiating a delegate and creating its object
            StringWriter("This is our text..."); // Calling the reference method
       }
    }
}