using System;
public class HelloWorld 
{
 //Method for Func delegate with return type
 public static double Sum(int x, float y, double z)
  {
       return (x + y + z); 
  } 
  //Method for Action delegate with out a return value
 public static void Sum2(int x, float y, double z)
  { 
      Console.WriteLine(x + y + z); 
  } 
 public static void Main(string[] args)
  {    //Func delegate assigned to a named method
       Func<int,float,double,double> add = Sum; 
       double result = add(100,55.8f,254.322); 
       Console.WriteLine(result); 
       //Func delegate assigned to an anonymous method
       Func<int,float,double,double> add2 = delegate (int x,float y, double z)
       {
          return(x+y+z);
       };
      double result2=add2(100,55.8f,254.322);
      Console.WriteLine(result2);
      //Func delegate assigned to a Lambda Expression
      Func<int,float,double,double> add3 = (int x,float y,double z)=>(x+y+z);
      double result3= add3(100,55.8f,254.322);
      Console.WriteLine(result3);
      //Action delegate assigned to a named method
      Action<int,float,double> adder = Sum2; 
      adder(100,55.8f,254.322);
      //Action delegate assigned to an anonymus method
      Action<int,float,double> adder2 = (int x,float y,double z) =>
      Console.WriteLine( x + y + z);
      adder2(100,55.8f,254.322);
      //Action delegate assigned to a Lamba Expression
      Action<int,float,double> adder3 = delegate(int x,float y,double z)
      {
          Console.WriteLine( x + y + z);
      };
      adder3(100,55.8f,254.322);
  }
}