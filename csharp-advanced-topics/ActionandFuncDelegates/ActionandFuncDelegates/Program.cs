namespace ActionandFuncDelagates
{
    public class Program
    {
       
        /* 
         * Define methods that match the delegate signature
         * integer return types
         */

        public int Add(int a, int b)
        {
            int result= a + b;
            //Console.WriteLine(result);
            return result;
        }

        //declare action delegate method signature
        //note the method return type is void
        public void ActionMethod(int a, int b)
        {
            Console.WriteLine(a*b);
        }


         
        // Create  delegate instances for mock tests
        public Program(Func<int , int ,int> Funcdel,Action<int,int> Actiondel)
        {
            Funcdel = Add;
            Actiondel = ActionMethod;
        }
     

       

       public static void Main(string[] args)
        {

            //Create delegate instances
            Func<int, int, int> Funcdel=(a,b)=>a+b;
            Action<int, int> Actiondel = (a, b) => Console.WriteLine(a*b);

            var program= new Program(Funcdel,Actiondel);
            // Use the delegates to perform math operations
            program.Add(5, 3);  //function delegate.returns 8

            program.ActionMethod(5, 3); //Action delegate.prints 15

            Console.ReadKey();
        }
    }

}


