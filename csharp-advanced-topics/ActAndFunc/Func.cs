namespace _Func
{
    public class Funcs
    {
        Func<int,int,int> addFunc = (a,b) => a+b; // return type int
        
        public int FuncMethod()
        {
          return addFunc(5,6);
        }


    }
}