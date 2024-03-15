// See https://aka.ms/new-console-template for more information
using CSharp_Action_Delegate;

//Non-Generic Action
var nonGenericActionDelegate = new NonGenericActionDelegate();
var processBmiNonGenericAction = nonGenericActionDelegate.ProcessBmi;

processBmiNonGenericAction();

// Generic Action
var genericActionDelegate = new GenericActionDelegate();
var processBmiGenericAction = genericActionDelegate.ProcessBmi;

processBmiGenericAction(175d, 75d);

//Lambda Expression Action
var lambdaActionDelegate = new LambdaActionDelegate();
lambdaActionDelegate.BmiWithNonGenericAction();
lambdaActionDelegate.BmiWithGenericAction(175d, 75d);