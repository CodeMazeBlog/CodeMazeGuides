using VirtualMethodsInCSharp;

BaseClass baseClass = new();
BaseClass derivedClassAsBaseClass = new DerivedClass();

var baseClassIntroduction = baseClass.IntroduceYourSelf();
Console.WriteLine(baseClassIntroduction);
var derivedClassAsBaseClassIntroduction = derivedClassAsBaseClass.IntroduceYourSelf();
Console.WriteLine(derivedClassAsBaseClassIntroduction);

DerivedClass derivedClass = new();
var derivedClassIntroduction = derivedClass.IntroduceYourSelf();
Console.WriteLine(derivedClassIntroduction);

var callingBaseClassIntroduction = derivedClass.CallBaseClassIntroduction();
Console.WriteLine(callingBaseClassIntroduction);

var baseClassFromDerivedClassIntroduction = derivedClass.IntroduceBaseClass();
Console.WriteLine(baseClassFromDerivedClassIntroduction);

var derivedClassNewKeyword = DerivedClass.IntroduceYourSelfForNewKeyword();
Console.WriteLine(derivedClassNewKeyword);

var derivedClassSealedKeyword = derivedClass.IntroduceYourSelfForSealedKeyword();
Console.WriteLine(derivedClassSealedKeyword);