## Polly in .NET: Retry, Circuit Breaker, and Fallback

Source code for [Polly in .NET: Retry, Circuit Breaker, and Fallback](https://code-maze.com/creating-resilient-microservices-in-net-with-polly/).

The sample is an API gateway (`Monolith`) in front of two microservices,
`AuthorsService` and `BooksService`. The gateway proxies requests to whichever
service the URL names, so stopping a service is enough to simulate a dependency
failure.

| Folder | What it is |
| - | - |
| `StarterCode` | The starting point — the gateway and the two services, with no resilience at all. Clone this one first if you want to follow the article step by step. |
| `FinishedCode` | The finished sample — the gateway executes every proxied call through a Polly v8 `ResiliencePipeline` with fallback, retry, and circuit-breaker strategies, and the Authors service simulates transient and slow failures. |
| `Tests` | Tests over the finished pipeline: the retry recovers a single transient failure, the fallback message is returned when every attempt fails, and the circuit opens and stops calling the dependency. |

Everything targets .NET 10 and Polly 8.

```
dotnet build ResilienceWithPolly.sln
dotnet test ResilienceWithPolly.sln
```

### Running the sample

Run all three projects — `AuthorsService` on `https://localhost:5001`,
`BooksService` on `https://localhost:6001`, and `Monolith` on
`https://localhost:7001` — then open `consumer.html` from the same folder in a
browser and use its two buttons. Stopping a service while the page is open is
what produces the failures the article walks through.
