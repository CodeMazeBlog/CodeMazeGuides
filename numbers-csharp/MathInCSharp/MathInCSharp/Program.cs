//general methods
Math.Abs(-1); //returns 1
Math.Max(3.7, 1.8);// returns  3.7
Math.Min(5, 10); // returns 5
Math.MaxMagnitude(-10.0, 3.0); //return -10
Math.MinMagnitude(-10.0, 3.0); // returns 3
long result =  Math.BigMul(Int32.MaxValue, Int32.MaxValue); // returns 4611686014132420609

long lowerBits = 0, arg1 = long.MaxValue, arg2 = long.MaxValue;
long higherBits = Math.BigMul(arg1, arg2, out lowerBits);

bool lhsIsSmaller = Math.BitDecrement(1.123) < 1.123; // returns true
bool rhsIsSmaller = Math.BitIncrement(1.123) > 1.123; // returns true

Math.Cbrt(8.0); //returns 2
Math.CopySign(10.0, -2.0); // returns -10
var (quotient, rem) = Math.DivRem(15, 7); // (quotient, rem) is (2, 1)
Math.FusedMultiplyAdd(1.0, 2.0, 3.0); // returns 1*2 + 3 = 5.0
Math.IEEERemainder(3, 2); //returns -1
var val = 3 % 2; // val is 1
Math.ReciprocalEstimate(2.0);// returns 0.5
Math.ReciprocalSqrtEstimate(4.0); // returns 1/(sqrt(4)) = 1/2 = 0.5
Math.Sign(-5.0); // returns -1
Math.Sqrt(4.0); // returns 2

//// exp and logs
///
Math.Exp(1); // returns 2.71..
Math.ILogB(9.0); // returns 3
Math.Log(Math.Exp(4.0));//returns 4
Math.Log(100, 10); // returns 2
Math.Log10(1000); // returns 3
Math.Log2(16); // returns 4
Math.Pow(3.0, 3.0); // returns 3^3 = 27
Math.ScaleB(3.0, 2); // returns 3.0*4=12

//trig functions
Math.Sin(Math.PI); // returns 0
Math.Cos(Math.PI); // returns -1
Math.Tan(Math.PI); // returns 0
Math.Asin(1); // returns Math.PI*0.5
Math.Acos(0); // returns Math.PI
Math.Atan(double.PositiveInfinity); // returns 1.5707...

Math.Sinh(0); // returns 0
Math.Cosh(0.0); // returns 1
Math.Tanh(0.0); //returns 0
Math.Asinh(0.0); // returns 0
Math.Acosh(1.0); // returns 0
Math.Atanh(0.0); // returns 0

//rounding methods
Math.Ceiling(3.001); // returns 4
Math.Ceiling(1.0); // returns 1
Math.Clamp(0.0, -1.0, 2.0); // returns 0
Math.Clamp(-10.0, -1.0, 2.0); // returns -1
Math.Clamp(10.0, -1.0, 2.0); // returns 2
Math.Floor(1.0); // returns 1
Math.Floor(1.3); // returns 1
Math.Floor(1.999); // returns 1
Math.Round(1.49); // returns 1
Math.Round(1.49, 1); // returns 1.5
Math.Truncate(-2.2); // returns -2
Math.Truncate(2.2); // returns 2

//fields

var pi = Math.PI; // returns 3.1415926535897931;
var e = Math.E; //returns 2.7182818284590451;

