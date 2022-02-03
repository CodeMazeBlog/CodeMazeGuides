using System;
using System.Timers;

namespace AFDemo
{
    public class Program
    {
       
        static void Main(string[] args)
        {
            Action DoThis = PrintMessage;
            CustomCountdown countdown = new CustomCountdown(10, DoThis);
            countdown.Start();
           
            Console.ReadLine();
        }

        public static void PrintMessage()
        {
            Console.WriteLine("Look dad I made it");
        }
    }

    public class CustomCountdown
    {
        public int TimeLeft { get; set; }
        Timer Timekeep { get; set; }
        public Action Callbackaction { get; set; }
        public CustomCountdown(int initial_time, Action action)
        {
            TimeLeft = initial_time;
            Callbackaction = action;
            Timekeep = new Timer(1000);
            Timekeep.Elapsed += Timekeep_Elapsed;
        }

        public void Start()
        { 
            Timekeep.Start();
        }

        private void Timekeep_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimeLeft -= 1;       

            if (TimeLeft<= 0)
            {
                Timekeep.Stop();
                Callbackaction();
            }
        }

        
    }
}
