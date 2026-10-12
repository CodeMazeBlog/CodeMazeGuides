# Build and Run .NET Applications With the CLI

Sample code for the Code Maze article [dotnet build and dotnet run: Using the .NET CLI](https://code-maze.com/dotnet-using-the-cli-to-build-and-run-net-applications/).

The folder holds the solution the article builds one command at a time:

- `HelloWorld`: a console app that references the `Flurl` package and the `HelloWorldCore` library.
- `HelloWorldCore`: a class library with one `Greeter` class.
- `HelloWorldTests`: an NUnit test project that references `HelloWorldCore` and tests `Greeter`.
- `HelloWorldSolution.sln`: the solution that groups the three projects.

To build, run and test it:

```
dotnet build
dotnet run --project HelloWorld
dotnet test
```

## Why the solution file here is a .sln

On the .NET 10 SDK, `dotnet new sln` creates an XML `.slnx` file, which is what the article shows. This
folder stores a `.sln` instead, created with `dotnet new sln --format sln`, because the repository's CI
looks for a `.sln` file in each sample folder. Both formats build the same three projects.

The test project here replaces the template's placeholder test with a real test of `Greeter`, and its
package versions are newer than the ones `dotnet new nunit` writes.

## The walkthrough, as captured on 2026-10-11

Every command below was run in order on Windows with .NET SDK 10.0.302 (runtime 10.0.10), so you can
compare your own output with it. The working folder was renamed to `C:\Workspace\CodeMaze` to match the
article. Two things are left out of the `dotnet add package` output: the three vulnerability-database
lines, because their dated URLs change every day, and the end of the `Installed Flurl` line, which names
the capture machine's NuGet package folder (on your machine it is the `.nuget\packages` folder in your
user profile) and the package's content hash. The cut is marked with `...`.

```
C:\Workspace\CodeMaze>dotnet new console -o HelloWorld
The template "Console App" was created successfully.

Processing post-creation actions...
Restoring C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj:
  Determining projects to restore...
  Restored C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj (in 74 ms).
Restore succeeded.
```

```
C:\Workspace\CodeMaze>cd HelloWorld
```

```
C:\Workspace\CodeMaze\HelloWorld>dotnet run
Hello, World!
```

```
C:\Workspace\CodeMaze\HelloWorld>dotnet build
  Determining projects to restore...
  All projects are up-to-date for restore.
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Debug\net10.0\HelloWorld.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.99
```

```
C:\Workspace\CodeMaze\HelloWorld>dotnet add package Flurl
info : X.509 certificate chain validation will use the default trust store selected by .NET for code signing.
info : X.509 certificate chain validation will use the default trust store selected by .NET for timestamping.
info : Adding PackageReference for package 'Flurl' into project 'C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj'.
info :   GET https://api.nuget.org/v3/registration5-gz-semver2/flurl/index.json
info :   OK https://api.nuget.org/v3/registration5-gz-semver2/flurl/index.json 553ms
info : Restoring packages for C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj...
info :   GET https://api.nuget.org/v3-flatcontainer/flurl/index.json
info :   OK https://api.nuget.org/v3-flatcontainer/flurl/index.json 234ms
info :   GET https://api.nuget.org/v3-flatcontainer/flurl/4.0.0/flurl.4.0.0.nupkg
info :   OK https://api.nuget.org/v3-flatcontainer/flurl/4.0.0/flurl.4.0.0.nupkg 87ms
info : Installed Flurl 4.0.0 from https://api.nuget.org/v3/index.json to ...
info : Package 'Flurl' is compatible with all the specified frameworks in project 'C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj'.
info : PackageReference for package 'Flurl' version '4.0.0' added to file 'C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj'.
info : Writing assets file to disk. Path: C:\Workspace\CodeMaze\HelloWorld\obj\project.assets.json
log  : Restored C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj (in 792 ms).
```

After replacing `Program.cs` with the article's four lines:

```
C:\Workspace\CodeMaze\HelloWorld>dotnet run
Hello, World!
https://api.site.com/area/class
```

```
C:\Workspace\CodeMaze\HelloWorld>dotnet publish
  Determining projects to restore...
  All projects are up-to-date for restore.
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Release\net10.0\HelloWorld.dll
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Release\net10.0\publish\
```

```
C:\Workspace\CodeMaze\HelloWorld>dir bin\Release\net10.0\publish /B
Flurl.dll
HelloWorld.deps.json
HelloWorld.dll
HelloWorld.exe
HelloWorld.pdb
HelloWorld.runtimeconfig.json
```

```
C:\Workspace\CodeMaze\HelloWorld>cd ..
```

```
C:\Workspace\CodeMaze>dotnet new classlib -o HelloWorldCore
The template "Class Library" was created successfully.

Processing post-creation actions...
Restoring C:\Workspace\CodeMaze\HelloWorldCore\HelloWorldCore.csproj:
  Determining projects to restore...
  Restored C:\Workspace\CodeMaze\HelloWorldCore\HelloWorldCore.csproj (in 73 ms).
Restore succeeded.
```

```
C:\Workspace\CodeMaze>dotnet new sln -n HelloWorldSolution
The template "Solution File" was created successfully.
```

```
C:\Workspace\CodeMaze>dotnet sln add .\HelloWorld\HelloWorld.csproj
Project `HelloWorld\HelloWorld.csproj` added to the solution.
```

```
C:\Workspace\CodeMaze>dotnet sln add .\HelloWorldCore\HelloWorldCore.csproj
Project `HelloWorldCore\HelloWorldCore.csproj` added to the solution.
```

```
C:\Workspace\CodeMaze>dotnet build
  Determining projects to restore...
  All projects are up-to-date for restore.
  HelloWorldCore -> C:\Workspace\CodeMaze\HelloWorldCore\bin\Debug\net10.0\HelloWorldCore.dll
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Debug\net10.0\HelloWorld.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.14
```

```
C:\Workspace\CodeMaze>cd HelloWorld
```

```
C:\Workspace\CodeMaze\HelloWorld>dotnet add reference ..\HelloWorldCore\HelloWorldCore.csproj
Reference `..\HelloWorldCore\HelloWorldCore.csproj` added to the project.
```

```
C:\Workspace\CodeMaze\HelloWorld>cd ..
```

```
C:\Workspace\CodeMaze>dotnet publish
  Determining projects to restore...
  Restored C:\Workspace\CodeMaze\HelloWorld\HelloWorld.csproj (in 278 ms).
  1 of 2 projects are up-to-date for restore.
  HelloWorldCore -> C:\Workspace\CodeMaze\HelloWorldCore\bin\Release\net10.0\HelloWorldCore.dll
  HelloWorldCore -> C:\Workspace\CodeMaze\HelloWorldCore\bin\Release\net10.0\publish\
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Release\net10.0\HelloWorld.dll
  HelloWorld -> C:\Workspace\CodeMaze\HelloWorld\bin\Release\net10.0\publish\
```

```
C:\Workspace\CodeMaze>dir HelloWorld\bin\Release\net10.0\publish /B
Flurl.dll
HelloWorld.deps.json
HelloWorld.dll
HelloWorld.exe
HelloWorld.pdb
HelloWorld.runtimeconfig.json
HelloWorldCore.dll
HelloWorldCore.pdb
```

```
C:\Workspace\CodeMaze>dotnet new nunit -o HelloWorldTests
The template "NUnit Test Project" was created successfully.

Processing post-creation actions...
Restoring C:\Workspace\CodeMaze\HelloWorldTests\HelloWorldTests.csproj:
  Determining projects to restore...
  Restored C:\Workspace\CodeMaze\HelloWorldTests\HelloWorldTests.csproj (in 10.24 sec).
Restore succeeded.
```

```
C:\Workspace\CodeMaze>dotnet sln add HelloWorldTests\HelloWorldTests.csproj
Project `HelloWorldTests\HelloWorldTests.csproj` added to the solution.
```

```
C:\Workspace\CodeMaze>cd HelloWorldTests
```

```
C:\Workspace\CodeMaze\HelloWorldTests>dotnet add reference ..\HelloWorldCore\HelloWorldCore.csproj
Reference `..\HelloWorldCore\HelloWorldCore.csproj` added to the project.
```

```
C:\Workspace\CodeMaze\HelloWorldTests>cd ..
```

```
C:\Workspace\CodeMaze>dotnet test
  Determining projects to restore...
  Restored C:\Workspace\CodeMaze\HelloWorldTests\HelloWorldTests.csproj (in 346 ms).
  2 of 3 projects are up-to-date for restore.
  HelloWorldCore -> C:\Workspace\CodeMaze\HelloWorldCore\bin\Debug\net10.0\HelloWorldCore.dll
  HelloWorldTests -> C:\Workspace\CodeMaze\HelloWorldTests\bin\Debug\net10.0\HelloWorldTests.dll
Test run for C:\Workspace\CodeMaze\HelloWorldTests\bin\Debug\net10.0\HelloWorldTests.dll (.NETCoreApp,Version=v10.0)
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     1, Skipped:     0, Total:     1, Duration: 34 ms - HelloWorldTests.dll (net10.0)
```
