using System;

namespace CodeMaze{
    class GenDel{
        // MCreating a Void Method
        public static void printSum(int x, float y, double z){
            Console.Write(x+y+z);

        }
        // Creating a non-void Method
        public static double addThree(int x, float y, double z){
        return x+y+z;

        }
        static void Main(){
            // Creating An Action Delegate
            Action<int, float, double> obj1 = printSum;
            obj1.Invoke(23,47.3f,595.11);
       
             // Creating a Func Delegate
            Func<int, float, double , double> obj2= addThree;
            double result = obj2.Invoke(56,56.23f,193.112);
            Console.Write(result);
       
        }        
    }
}