# Swashbuckle vs. NSwag in ASP.NET Core

Sample for the Code Maze article [Swashbuckle vs. NSwag in ASP.NET Core](https://code-maze.com/aspnetcore-swashbuckle-vs-nswag/).

| Project | What it shows |
|---|---|
| `SwashbuckleVsNSwag.BuiltIn` | The built-in generator (`AddOpenApi()` and `MapOpenApi()`, JSON and YAML) with Swagger UI from `Swashbuckle.AspNetCore.SwaggerUi` |
| `SwashbuckleVsNSwag.Swashbuckle` | `AddSwaggerGen()`, `UseSwagger()` and `UseSwaggerUI()` |
| `SwashbuckleVsNSwag.NSwag` | `AddOpenApiDocument()`, `UseOpenApi()`, `UseSwaggerUi()` at `/swagger` and `UseReDoc()` at `/redoc` |
| `SwashbuckleVsNSwag.Benchmark` | BenchmarkDotNet GET and POST calls against the Swashbuckle and NSwag apps |

All three web apps serve their documentation in the Development environment only.

## Running the benchmark

The benchmark calls two running apps, so start both first, each in its own terminal, on their `https` profiles:

```
dotnet run --project SwashbuckleVsNSwag.Swashbuckle --launch-profile https   # https://localhost:7060
dotnet run --project SwashbuckleVsNSwag.NSwag --launch-profile https         # https://localhost:7089
```

Then run the benchmark in Release:

```
dotnet run -c Release --project SwashbuckleVsNSwag.Benchmark
```

If either app is not running, every benchmark reports `NA`.
