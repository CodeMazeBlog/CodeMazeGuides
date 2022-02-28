int resultNumber = 0;
string resultMessage = "";

Action<string> MessageView = ShowMessage;
MessageView("Code Maze in Action");
Console.WriteLine($"Action with single = {resultMessage}");

Action<int, int> MultiplicationMethod = MultiplyNumbers;
MultiplicationMethod(10, 20);
Console.WriteLine($"Action without lambda value = {resultNumber}");

Action<int, int> MultiplicationMethodLambda = (a, b) => MultiplyNumbers(a, b);
MultiplicationMethod(10, 20);
Console.WriteLine($"Action with lambda value = {resultNumber}");


void MultiplyNumbers(int paramX, int paramY) 
{ 
    resultNumber = paramX * paramY; 
}
void ShowMessage(string param) 
{ 
    resultMessage = param; 
}
