using VirtualMethodsInCSharp;

BaseClass baseClass = new();
BaseClass derivedClassAsBaseClass = new DerivedClass();

var baseClassVirtualMethodA = baseClass.VirtualMethodA();
Console.WriteLine(baseClassVirtualMethodA);
var derivedClassAsBaseClassVirtual = derivedClassAsBaseClass.VirtualMethodA();
Console.WriteLine(derivedClassAsBaseClassVirtual);

DerivedClass derivedClass = new();
var baseClassVirtualMethodB = baseClass.VirtualMethodB();
Console.WriteLine(baseClassVirtualMethodB);
var derivedClassNotOverridingVirtualMethod = derivedClass.VirtualMethodB();
Console.WriteLine(derivedClassNotOverridingVirtualMethod);

var baseClassNonVirtualMethod = baseClass.NonVirtualMethod();
Console.WriteLine(baseClassNonVirtualMethod);
var derivedClassNonVirtualMethodWithNewKeyword = derivedClass.NonVirtualMethod();
Console.WriteLine(derivedClassNonVirtualMethodWithNewKeyword);