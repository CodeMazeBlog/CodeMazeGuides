// See https://aka.ms/new-console-template for more information

using FuncActionDelegate;

Dog dog = new Dog();

//declaration
//Action<string> dogSoundDelegate = dog.PrintSound;
//invocation
//dogSoundDelegate("wuff!!!!");


//declaration
Func<string, string> dogSoundDelegateValue = dog.MakeSound;
//invocation
var sound = dogSoundDelegateValue("wuff!!!wuff!!!");
Console.WriteLine(sound);

