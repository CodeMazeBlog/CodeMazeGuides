// See https://aka.ms/new-console-template for more information

using CSharp_Func_Delegate;

//Func delegate without input parameters
FuncDelegateWithoutInputParameter funcDelegateWithoutInputParameter = new FuncDelegateWithoutInputParameter();
Func<double> processfuncDelegateWithoutInputParameter = funcDelegateWithoutInputParameter.ProcessBmi;
Console.WriteLine($"The BMI is : {processfuncDelegateWithoutInputParameter():N}.");

//Func delegate with input parameters
FuncDelegateWithInputParameter funcDelegateWithInputParameter = new FuncDelegateWithInputParameter();
Func<double, double, double> processFuncDelegateWithInputParameter = funcDelegateWithInputParameter.ProcessBmi;
Console.WriteLine($"The BMI is : {processFuncDelegateWithInputParameter(175d, 75d):N}.");

//Func delegate with lambda expressions
FuncDelegateLambdaExpression funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
Console.WriteLine($"The BMI is : {funcDelegateLambdaExpression.ProcessBmiWithInputParametersFunc(175d, 75d):N}.");
Console.WriteLine($"The BMI is : {funcDelegateLambdaExpression.ProcessBmiWithNoInputParametersFunc():N}.");
