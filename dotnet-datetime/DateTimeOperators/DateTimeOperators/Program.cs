using DateTimeOperators;

public class Program
{
    static void Main(string[] args)
    {
        //declaration of variables
        DateTime dt = new DateTime(2022, 1, 1);
        DateTime dt1 = new DateTime(2023, 1, 1);
        TimeSpan ts = new TimeSpan(20, 4, 2, 1);
        var operators = new Operators();

        //addition operation
        var result = operators.AddOperation(dt, ts);
        Console.WriteLine("The sum of {0} and {1} is {2}", dt, ts, result);

        //Equality operation
        var equal = operators.EqualityOperation(dt, dt);
        if (equal == true)
            Console.WriteLine("{0} and {1} are equal", dt, dt);

        //Greater than operation 
        var greater = operators.GreaterThanOperation(dt1, dt);
        if (greater == true)
            Console.WriteLine("{0} is greater than {1}", dt1, dt);

        //Greater than or equal to operation 
        var greaterOrEqual = operators.GreaterThanOrEqualOperation(dt1, dt);
        if (greaterOrEqual == true)
            Console.WriteLine("{0} is greater than or equal to {1}", dt1, dt);

        //Inequality operation 
        var inequality = operators.InequalityOperation(dt1, dt);
        if(inequality == true)
            Console.WriteLine("{0} is not equal to {1}", dt1, dt);

        //Less than operation 
        var less = operators.LessThanOperation(dt, dt1);
        if (less == true)
            Console.WriteLine("{0} is less than {1}", dt, dt1);

        //Less than or equal to operation 
        var lessOrEqual = operators.LessThanOperation(dt, dt1);
        if (lessOrEqual == true)
            Console.WriteLine("{0} is less than {1}", dt, dt1);

        //Compare to operator
        var equalTo = operators.CompareDates(dt, dt);
        if(equalTo == 0)
            Console.WriteLine("{0} and {1} are equal", dt, dt);
        var lessThan = operators.CompareDates(dt, dt1);
        if(lessThan < 0)
            Console.WriteLine("{0} is less than {1}", dt, dt1);
        var moreThan = operators.CompareDates(dt1, dt);
        if(moreThan > 0)
            Console.WriteLine("{0} is greater than {1}", dt1, dt);

        //Subtract operation 
        var subtractDate = operators.SubtractOperation(dt1, dt);
        var subtractTimeSpan = operators.SubtractOperation(dt, ts);
        Console.WriteLine("Subtracting {0} from {1} gets {2} as the result", dt, dt1, subtractDate);
        Console.WriteLine("Subtracting {0} from {1} gets {2} as the result", ts, dt, subtractTimeSpan);
    }
}

