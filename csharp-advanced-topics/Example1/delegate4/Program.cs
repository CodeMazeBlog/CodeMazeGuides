using System;

public class Test {

            public static void Main() {

                        Action NonGen = new Action(Display);

                        NonGen();

            }

            public static void Display() {

                        Console.WriteLine("Non-generic Action Delegate.");

    }

 }