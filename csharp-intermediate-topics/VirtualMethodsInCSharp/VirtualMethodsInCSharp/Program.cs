using VirtualMethodsInCSharp;

BaseClass baseClass = new();
BaseClass derivedClassAsBaseClass = new DerivedClass();

var baseClassVirtualMethodA = baseClass.VirtualMethodA();
Console.WriteLine(baseClassVirtualMethodA);
var derivedClassAsBaseClassVirtual = derivedClassAsBaseClass.VirtualMethodA();
Console.WriteLine(derivedClassAsBaseClassVirtual);

var baseClassVirtualMethodB = baseClass.VirtualMethodB();
Console.WriteLine(baseClassVirtualMethodB);
var derivedClassAsBaseClassNotOverridingVirtualMethod = derivedClassAsBaseClass.VirtualMethodB();
Console.WriteLine(derivedClassAsBaseClassNotOverridingVirtualMethod);

var baseClassNonVirtualMethod = baseClass.NonVirtualMethod();
Console.WriteLine(baseClassNonVirtualMethod);
var derivedClassAsBaseClassNonVirtualMethodWithNewKeyword = derivedClassAsBaseClass.NonVirtualMethod();
Console.WriteLine(derivedClassAsBaseClassNonVirtualMethodWithNewKeyword);

DerivedClass derivedClass = new();
var derivedClassNonVirtualMethod = derivedClass.NonVirtualMethod();
Console.WriteLine(derivedClassNonVirtualMethod);