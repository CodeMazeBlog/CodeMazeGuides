using BenchmarkDotNet.Running;
using CompareByteArraysInCsharp;

var summary = BenchmarkRunner.Run<CompareByteArrays>();