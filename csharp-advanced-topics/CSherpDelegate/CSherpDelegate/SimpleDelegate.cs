using System;

namespace CodeMaze {
    public delegate void WriteStr(string str); 
    
    class SimpleDelegate {

        public static void MyWrite(string str){
            Console.WriteLine("Output :"+str);
        }

        static void Main(string[] args){
             WriteStr StringDelegate = new  WriteStr(MyWrite); // Intantiating a delegate and creating its object
             StringDelegate("This is a text !!!"); // Calling the reference method
        }
    }
}