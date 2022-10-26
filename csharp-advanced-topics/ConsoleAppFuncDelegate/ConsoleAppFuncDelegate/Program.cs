using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTestDelegates
{

    public class Program
    {

        delegate double ArithMeticProcessing(double dblParaA, double dblParaB);

        
        static double AddNumber(double dblPA, double dblPB)
        {

            double dblResult = dblPA + dblPB;

            return dblResult;


        }

        static double SubNumber(double dblPA, double dblPB)
        {

            double dblResult = dblPA - dblPB;

            return dblResult;


        }

        static double MulNumber(double dblPA, double dblPB)
        {

            double dblResult = dblPA * dblPB;

            return dblResult;


        }


        static double DivNumber(double dblPA, double dblPB)
        {

            double dblResult = dblPA / dblPB;

            return dblResult;


        }

        public static void Main(string[] args)
        {


            ArithMeticProcessing dArthNum = null;

            Console.WriteLine("Enter 2 Numbers seperated with Comma...!!!");
            string strInput = Console.ReadLine();

            int intComPos = strInput.IndexOf(',');


            double dblPaA = Convert.ToDouble(strInput.Substring(0, intComPos));
            double dblPaB = Convert.ToDouble(strInput.Substring(intComPos + 1, strInput.Length - intComPos - 1));

            // Based on inputs

            Console.WriteLine("Enter A for Addition \n S for Subtraction  \n M for Multipulcation \n D for Division ");
            Console.Write("Enter your Choice...!!! :  ");

            string strChoice = Console.ReadLine();

            string strOutput = "";

            switch (strChoice)
            {

                case "a":
                case "A":
                    dArthNum = new ArithMeticProcessing(AddNumber);
                    strOutput = "Addtion";
                    break;

                case "s":
                case "S":
                    dArthNum = new ArithMeticProcessing(SubNumber);
                    strOutput = "Subtraction";
                    break;

                case "m":
                case "M":
                    dArthNum = new ArithMeticProcessing(MulNumber);
                    strOutput = "Multipulcation";
                    break;

                case "d":
                case "D":
                    dArthNum = new ArithMeticProcessing(DivNumber);
                    strOutput = "Division";
                    break;

            }

            Console.WriteLine("The Arithmetic Result for " + strOutput + " is " + dArthNum(dblPaA, dblPaB));
            Console.ReadLine();


        }
    }
}

