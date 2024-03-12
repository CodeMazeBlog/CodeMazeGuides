// See https://aka.ms/new-console-template for more information
using CSharp_Action_Delegate;

//Non-Generic Action
NonGenericActionDelegate nonGenericActionDelegate = new NonGenericActionDelegate();
Action processBmiNonGenericAction = nonGenericActionDelegate.ProcessBmi;

processBmiNonGenericAction();

// Generic Action
GenericActionDelegate genericActionDelegate = new GenericActionDelegate();
Action<double, double> processBmiGenericAction = genericActionDelegate.ProcessBmi;

processBmiGenericAction(175d, 75d);

//Lambda Expression Action
LambdaActionDelegate lambdaActionDelegate = new LambdaActionDelegate();
lambdaActionDelegate.BmiWithNonGenericAction();
lambdaActionDelegate.BmiWithGenericAction(175d, 75d);