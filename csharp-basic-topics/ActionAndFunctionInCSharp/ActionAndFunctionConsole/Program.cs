// See https://aka.ms/new-console-template for more information
using ActionAndFunctionConsole.Services;

ConverterService converterUpper = new ConverterService((_) => _.ToUpper());
//We set Action as a Log before the method start
converterUpper.beforeAction = Utils.MethodStarted;
Console.WriteLine(converterUpper.Convert("upper-example"));

//We define ToLower method for Function.
ConverterService converterLower = new ConverterService((_) => _.ToLower());
converterLower.beforeAction = Utils.MethodStarted;
Console.WriteLine(converterLower.Convert("LOWER-EXAMPLE"));
