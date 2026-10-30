# gRPC vs REST in ASP.NET Core

One ASP.NET Core app (`GrpcVsRest.Server`) serves the same product catalog as a minimal API, as a gRPC service, as JSON through gRPC JSON transcoding, and as gRPC-Web. `GrpcVsRest.Benchmarks` calls it every way and measures it.

Build and test from this folder:

```
dotnet build GrpcVsRest.sln -c Release
dotnet test GrpcVsRest.sln -c Release --no-build
```

Run the measurements (each command starts its own copy of the server on ports 5100 and 5101, so stop any other server on those ports first):

```
dotnet run -c Release --project GrpcVsRest.Benchmarks -- demo
dotnet run -c Release --project GrpcVsRest.Benchmarks -- sizes
dotnet run -c Release --project GrpcVsRest.Benchmarks -- wire
dotnet run -c Release --project GrpcVsRest.Benchmarks -- --filter "*SerializationBenchmarks*"
dotnet run -c Release --project GrpcVsRest.Benchmarks -- --filter "*CallBenchmarks*"
```

The timings belong to the machine they ran on. Run them on your own hardware, ideally with nothing else running, and compare the ways of calling with each other rather than with our numbers.
