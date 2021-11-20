using System;
using System.Collections.Generic;

namespace FuncAndActionDelegateInCSharp
{
    public enum Grading
    {
        Bad,
        Average,
        Best
    }
    public class DataStudent
    {
        public string FullName { get; set; }
        public int Score { get; set; }
        public Grading Grade { set; get; }
    }

    public class Course
    {
        public static Func<int, Grading> doGrade = GradeMethod.doGradingStandar2;
        public static Action<string> WriteMessage = GradeMethod.PrintToConsole;
        public static Grading minGradLevel { get; set; } = Grading.Average;
        public List<DataStudent> Students { get; set; } = new List<DataStudent>();
        public void printGrade(DataStudent a)
        {
            a.Grade = doGrade(a.Score);

            if (a.Grade < minGradLevel) return;

            var output = "Student " + a.FullName + " with Grade " + a.Grade.ToString();
            WriteMessage(output);
        }
    }

    public static class GradeMethod
    {
        public static void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }
        public static Grading doGradingStandar1(int score)
        {
            if (score > 60 && score <= 70) return Grading.Bad;
            else if (score >= 71 && score <= 80) return Grading.Average;
            else return Grading.Best;
        }
        public static Grading doGradingStandar2(int score)
        {
            if (score > 50 && score <= 60) return Grading.Bad;
            else if (score >= 61 && score <= 71) return Grading.Average;
            else return Grading.Best;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> Sums = doCalculate;
            int result = doCalculate(10, 20);
            Console.WriteLine("Result Func Delegate " + result);
            Console.WriteLine();

            Action<int> firstActionDelegate = ActionWithOneParameter;
            Action<int, int> secondActionDelegate = ActionWithTwoParameters;

            firstActionDelegate(1);
            secondActionDelegate(1, 2);
            Console.WriteLine();

            Course course = new Course();
            course.Students.Add(new DataStudent()
            {
                FullName = "Mutiara",
                Score = 70
            });
            course.Students.Add(new DataStudent()
            {
                FullName = "Rizky",
                Score = 80
            });
            course.Students.Add(new DataStudent()
            {
                FullName = "Ayu",
                Score = 100
            });

            foreach (DataStudent student in course.Students)
            {
                course.printGrade(student);
            }

            Console.ReadLine();
        }
        private static int doCalculate(int param1, int param2)
        {
            return param1 + param2;
        }
        public static void ActionWithOneParameter(int arg)
        {
            Console.WriteLine(arg);
        }

        public static void ActionWithTwoParameters(int arg1, int arg2)
        {
            Console.WriteLine(arg1 + " and " + arg2);
        }
    }
}
