// See https://aka.ms/new-console-template for more information
Console.WriteLine("Func and Action delegates");

Func<int, int, int> Power = PoweredTo;

int power = Power(10,5);



Console.WriteLine(power);

Func <int, int, int> PowerAnonymous = delegate (int baseNumber, int exponent) {
    return (int)Math.Pow(baseNumber, exponent);
};

int powerAnonymous = PowerAnonymous(10,5); 

Console.WriteLine(powerAnonymous);

Func <int, int, int> PowerLambda = (int baseNumber, int exponent) =>
    (int)Math.Pow(baseNumber, exponent);

int powerLambda = PowerLambda(10,5); 

Console.WriteLine(powerLambda);

int PoweredTo(int baseNumber, int exponent) {
    return (int)Math.Pow(baseNumber, exponent);
}

int powerActionAnonymousResult = 0;
int powerActionLambdaResult = 0;


Action<int, int> PoweredActionAnonymous = delegate (int baseNumber, int exponent) {
    powerActionAnonymousResult = (int)Math.Pow(baseNumber, exponent);
};

PoweredActionAnonymous(10,5);
Console.WriteLine(powerActionAnonymousResult);

Action<int, int> PoweredActionLambda = (int baseNumber, int exponent) => 
    powerActionLambdaResult = (int)Math.Pow(baseNumber, exponent);

PoweredActionLambda(10,5);
Console.WriteLine(powerActionLambdaResult);

int powerActionResult = 0;

Action<int, int> PowerAction = PoweredToAction;

PowerAction(10,5);

Console.WriteLine(powerActionResult);

void PoweredToAction(int baseNumber, int exponent) {
    powerActionResult = (int)Math.Pow(baseNumber, exponent);
}

