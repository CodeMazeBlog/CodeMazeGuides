# C# vs Java: Which One Should You Pick?

Sample code for the Code Maze article [C# vs Java: Which One Should You Pick?](https://code-maze.com/csharp-vs-java/).

Each difference the article shows is one small program in both languages:

| Demo | C# (console app) | Java (single-file program) |
|---|---|---|
| Generics at runtime | `GenericsDemo.cs` | `java/Generics.java` |
| Memory for a million numbers | `MemoryDemo.cs` | `java/Memory.java` |
| 10,000 one-second waits | `ConcurrencyDemo.cs` | `java/Concurrency.java` |
| Grouping query | `LinqDemo.cs` | `java/Orders.java` |
| Records and pattern matching | `ShapesDemo.cs` | `java/Shapes.java` |
| Null safety | `NullDemo.cs` | `java/Nulls.java` |
| Properties, operators, checked exceptions | `EverydayDemo.cs` | `java/Everyday.java` |

## Running the C# demos

You need the .NET 10 SDK. From this folder, pass the name of one demo:

```
dotnet run --project CSharpVsJava -- generics
```

The names are `generics`, `memory`, `concurrency`, `linq`, `shapes`, `nulls`, `nulls-unchecked` and `everyday`.

The build prints one warning on purpose, CS8602 in `NullDemo.RunUnchecked()`, and `nulls-unchecked` ends in a `NullReferenceException`. That is the bug the article asks the compiler to catch.

## Running the Java programs

You need JDK 25 or later. Each file runs on its own, with no Maven or Gradle project:

```
cd java
java Generics.java
```

`Nulls.java` ends in a `NullPointerException` (exit code 1) on purpose, and `Everyday.java` expects no `orders.csv` in the folder it runs from.

## A note on CI

The repository's CI builds this folder through `CSharpVsJava.sln`, so it compiles the C# project only. It does not compile or run the files in `java/`. They are here so the reader can run both sides, and we ran them with Eclipse Temurin 25 when we wrote the article.
