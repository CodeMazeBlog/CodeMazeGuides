// See https://aka.ms/new-console-template for more information

using CSharp_Func_Delegate;

//Func delegate without input parameters
var funcDelegateWithoutInputParameter = new FuncDelegateWithoutInputParameter();
var processfuncDelegateWithoutInputParameter = funcDelegateWithoutInputParameter.ProcessBmi;
Console.WriteLine($"The BMI is : {processfuncDelegateWithoutInputParameter():N}.");

//Func delegate with input parameters
var funcDelegateWithInputParameter = new FuncDelegateWithInputParameter();
var processFuncDelegateWithInputParameter = funcDelegateWithInputParameter.ProcessBmi;
Console.WriteLine($"The BMI is : {processFuncDelegateWithInputParameter(175d, 75d):N}.");

//Func delegate with lambda expressions
var funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
Console.WriteLine($"The BMI is : {funcDelegateLambdaExpression.ProcessBmiWithInputParametersFunc(175d, 75d):N}.");
Console.WriteLine($"The BMI is : {funcDelegateLambdaExpression.ProcessBmiWithNoInputParametersFunc():N}.");
