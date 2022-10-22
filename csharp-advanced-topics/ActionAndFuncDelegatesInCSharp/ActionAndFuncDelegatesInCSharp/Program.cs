using ActionAndFuncDelegatesInCSharp;

FuncDelegate.FindRootUsingFuncReferringANamedMethod(25);
FuncDelegate.FindRootUsingFuncReferringAnAnonymousMethod(25);
FuncDelegate.FindRootUsingFuncReferringALambdaExpression(25);
FuncDelegate.FindSumByInvokingFuncUsingInvoke(5, 10);
FuncDelegate.GettingReturnValueOfIndividualFromAMulticastDelegate(new[] { 90, 85, 20 });

ActionDelegate.LogUsingActionReferringANamedMethod();
ActionDelegate.LogUsingActionReferringAnAnonymousMethod();
ActionDelegate.LogUsingActionReferringALambdaExpression();
ActionDelegate.CallingActionUsingInvoke();
ActionDelegate.FormingMulticastDelegateUsingActions();