﻿namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
{
}