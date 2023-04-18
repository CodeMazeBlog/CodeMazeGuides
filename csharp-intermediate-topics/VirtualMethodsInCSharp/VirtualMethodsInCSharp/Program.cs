using VirtualMethodsInCSharp;

BaseClass baseClass = new();
BaseClass derivedClassAsBaseClass = new DerivedClass();

var baseClassIntroduction = baseClass.IntroduceYourSelf();
Console.WriteLine(baseClassIntroduction);
var derivedClassIntroduction = derivedClassAsBaseClass.IntroduceYourSelf();
Console.WriteLine(derivedClassIntroduction);

DerivedClass derivedClass = new();
var baseClassFromDerivedClassIntroduction = derivedClass.IntroduceBaseClass();
Console.WriteLine(baseClassFromDerivedClassIntroduction);

var derivedClassNotOverriden = derivedClass.IntroduceYourSelfNotOverriden();
Console.WriteLine(derivedClassNotOverriden);

var derivedClassNewKeyword = derivedClass.IntroduceYourSelfForNewKeyword();
Console.WriteLine(derivedClassNewKeyword);

var derivedClassSealedKeyword = derivedClass.IntroduceYourSelfForSealedKeyword();
Console.WriteLine(derivedClassSealedKeyword);