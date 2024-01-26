// See https://aka.ms/new-console-template for more information

#region (Func Delegate)

// Declaring a Func delegate named funcFact that takes an int parameter and returns an int
Func<int, int> funcFact = GetFactorial;

// Assigning a value (7) to the variable fNum
int fNum = 7;

// Invoking the funcFact delegate with the value of fNum to calculate the factorial
int factResult = funcFact(fNum);

// Displaying the result
Console.WriteLine($"Factorial of {fNum} is {factResult}");

// Defining a method named GetFactorial to calculate the factorial of a given number
int GetFactorial(int factNum)
{
    int i, fact = 1;

    // Using a for loop to calculate the factorial
    for (i = 1; i <= factNum; i++)
    {
        fact = fact * i;
    }

    // Returning the calculated factorial
    return fact;
}

#region (Anonymous Method)

// Declaring a Func delegate named fCalulate that takes two int parameters and returns an int
Func<int, int, int> fCalulate = (x, y) => { return x * y; };

// Invoking the fCalulate delegate with the values 17 and 23 to perform multiplication
int productResult = fCalulate(17, 23);

// Displaying the result of the multiplication
Console.WriteLine($"The multiplication result is {productResult}");
#endregion

#endregion

#region (Action Delegate)

#region (Anonymous Method)

// Declaring an Action delegate named aCharLen that takes a string parameter
Action<string> aCharLen = str => { Console.WriteLine($"Length of {str} is {str.Length}"); };

// Invoking the aCharLen delegate with the string "qwerty" to print its length
aCharLen.Invoke("qwerty");

#endregion


// Declaring an Action delegate named aPrime that takes an int parameter
Action<int> aPrime = IsPrimeNumber;

// Invoking the aPrime delegate with the value 13 to check if it's a prime number
aPrime.Invoke(13);

// Defining a method named IsPrimeNumber to determine whether a given number is prime
void IsPrimeNumber(int num)
{
    int a = 0;

    // Using a for loop to check for factors of the given number
    for (int i = 1; i <= num; i++)
    {
        if (num % i == 0)
        {
            a++;
        }
    }

    // Checking if the given number has exactly two factors (prime number condition)
    if (a == 2)
    {
        Console.WriteLine($"{num} is a Prime Number");
    }
    else
    {
        Console.WriteLine($"{num} is Not a Prime Number");
    }

    // Allowing the user to read the result before the program exits
    Console.ReadLine();
}




#endregion