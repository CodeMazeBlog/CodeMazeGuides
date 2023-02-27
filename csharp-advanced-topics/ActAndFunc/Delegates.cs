namespace _Delegate
{
    public class Delegates
    {

      public delegate void SayHello(string message); 

      public static void Method(string message) 
      {
        Console.WriteLine(message);
      }
      
      public void DelegateMethod()
      {
        SayHello sayHello = new SayHello(Method); 
        sayHello("Hello World!");
        sayHello.Invoke("Hello World! (Invoke)");
      }
  
    public void Add(int a,int b){
      Console.WriteLine(a+b);
    }
    public void Subtract(int a,int b){
      Console.WriteLine(a-b);
    }
    public delegate void MultiDelegate(int a,int b);

    public void MultiDelegateMethod(int a,int b){
      MultiDelegate multiDelegate = new MultiDelegate(Add);
      multiDelegate += Subtract;
      multiDelegate(a,b);
    }
    }
}