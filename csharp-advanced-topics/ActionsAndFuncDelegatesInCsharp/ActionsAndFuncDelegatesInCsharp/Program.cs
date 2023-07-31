using ActionsAndFuncDelegatesInCsharp;

double x = 30, y = 40;
string input = "codemaze", sendUsing = "email", operationToPerform = "+";

Action<double, string> sendAction = sendUsing switch
{
	"email" => SendResult.SendByEmail,
	"callback" => SendResult.SendByCallback,
	_ => SendResult.SendToConsole
};

Func<double, double, double> operation = operationToPerform switch
{
	"-" => CalculatorActivity.SubtractActivity,
	"*" => CalculatorActivity.MultiplyActivity,
	"/" => CalculatorActivity.DivideActivity,
	_ => CalculatorActivity.SumActivity
};

Calculator.PerformOperation(x, y, input, operation, sendAction);