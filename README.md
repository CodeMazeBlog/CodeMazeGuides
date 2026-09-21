<div align="center">

# Code Maze Guides

**The source code for 800+ C# and .NET articles from [code-maze.com](https://code-maze.com/?source=github).**<br>Every article gets its own runnable solution, most with tests.

[![Stars](https://img.shields.io/github/stars/CodeMazeBlog/CodeMazeGuides?style=flat&logo=github)](https://github.com/CodeMazeBlog/CodeMazeGuides/stargazers) [![Forks](https://img.shields.io/github/forks/CodeMazeBlog/CodeMazeGuides?style=flat&logo=github)](https://github.com/CodeMazeBlog/CodeMazeGuides/network/members) [![PR Build](https://github.com/CodeMazeBlog/CodeMazeGuides/actions/workflows/pr-build.yml/badge.svg)](https://github.com/CodeMazeBlog/CodeMazeGuides/actions/workflows/pr-build.yml) [![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE) [![.NET](https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)

[Blog](https://code-maze.com/?source=github) · [Courses](https://courses.code-maze.com/courses/?source=github) · [YouTube](https://www.youtube.com/@CodeMaze) · [Report an issue](https://github.com/CodeMazeBlog/CodeMazeGuides/issues)

</div>

---

## Contents

- [About](#about)
- [Quick start](#quick-start)
- [Browse by topic](#browse-by-topic)
- [Repository layout](#repository-layout)
- [Contributing](#contributing)
- [Support Code Maze](#support-code-maze)
- [License](#license)

## About

Code Maze is a blog about C# and .NET, written with simplicity and pragmatism in mind. The articles are hands-on. They focus on the core of each topic and show working code, not theory alone.

This repository holds that code. If you came here from an article, the article links to its exact folder. If you are just browsing, pick a topic below.

## Quick start

You need the [.NET SDK](https://dotnet.microsoft.com/download). Each project states its target framework in its `.csproj` file, so install the version that project asks for.

```bash
git clone https://github.com/CodeMazeBlog/CodeMazeGuides.git
cd CodeMazeGuides/<topic>/<article-folder>
dotnet build
dotnet run
dotnet test
```

> [!TIP]
> The full repository is large. To get only one article, use a sparse checkout:
>
> ```bash
> git clone --filter=blob:none --sparse https://github.com/CodeMazeBlog/CodeMazeGuides.git
> cd CodeMazeGuides
> git sparse-checkout set <topic>/<article-folder>
> ```

## Browse by topic

The numbers show how many article projects each folder holds.

### C# language

| Topic | Projects |
| --- | ---: |
| [C# basics](csharp-basic-topics) | 45 |
| [C# intermediate](csharp-intermediate-topics) | 48 |
| [C# advanced](csharp-advanced-topics) | 28 |
| [Classes, structs and records](csharp-classes-struct-record) | 11 |
| [Methods](csharp-methods) | 9 |
| [Operators](csharp-operators) | 5 |
| [Strings](strings-csharp) | 39 |
| [Numbers](numbers-csharp) | 19 |
| [LINQ](csharp-linq) | 20 |
| [Async programming](async-csharp) | 11 |
| [Threads](threads-csharp) | 7 |
| [Exception handling](exception-handling) | 10 |
| [Refactoring](csharp-refactoring) | 5 |

### Collections

| Topic | Projects |
| --- | ---: |
| [Collections](collections-csharp) | 24 |
| [Arrays](collections-arrays) | 24 |
| [Lists](collections-lists) | 16 |
| [Dictionaries](collections-dictionary) | 9 |

### ASP.NET Core and Blazor

| Topic | Projects |
| --- | ---: |
| [ASP.NET Core Web API](aspnetcore-webapi) | 56 |
| [ASP.NET Core features](aspnetcore-features) | 52 |
| [Authentication and authorization](authorization-dotnet) | 23 |
| [Query strings](dotnet-querystrings) | 6 |
| [Blazor features](blazor-features) | 11 |
| [Blazor libraries](blazor-libraries) | 2 |
| [Angular](angular) | 1 |

### Data and serialization

| Topic | Projects |
| --- | ---: |
| [Entity Framework Core](dotnet-efcore) | 28 |
| [Dapper](dotnet-dapper) | 4 |
| [MongoDB](dotnet-mongo-db) | 3 |
| [JSON](json-csharp) | 29 |
| [XML](xml-csharp) | 6 |
| [Files and streams](files-csharp) | 23 |
| [Date and time](dotnet-datetime) | 22 |
| [Searching](dotnet-searching) | 1 |

### Architecture and design

| Topic | Projects |
| --- | ---: |
| [Design patterns](csharp-design-patterns) | 12 |
| [Architectural patterns](csharp-architectural-patterns) | 13 |
| [Domain-driven design](domain-driven%20design) | 1 |
| [Dependency injection](dotnet-dependency-injection) | 11 |
| [DI tools](dependency-injection-tools) | 3 |
| [Microservices](dotnet-microservices) | 2 |

### Libraries, tooling and operations

| Topic | Projects |
| --- | ---: |
| [Client libraries](dotnet-client-libraries) | 60 |
| [Base libraries](dotnet-base-libraries) | 3 |
| [Testing](dotnet-testing) | 32 |
| [Logging](dotnet-logging) | 13 |
| [Performance](dotnet-performance) | 9 |
| [.NET CLI](dotnet-cli) | 2 |
| [Visual Studio](visual-studio) | 5 |
| [Deployment](dotnet-deployment) | 2 |
| [Platform-specific code](dotnet-platform-specific) | 3 |
| [Projects](dotnet-projects) | 13 |

### Algorithms, AI and more

| Topic | Projects |
| --- | ---: |
| [Algorithms](csharp-algorithms) | 13 |
| [Machine learning](csharp-machine-learning) | 5 |
| [AI](csharp-ai) | 1 |
| [Images](csharp-images) | 3 |

## Repository layout

```text
CodeMazeGuides/
├── <topic>/                  # one folder per topic, e.g. aspnetcore-webapi
│   └── <article-folder>/     # one folder per article
│       ├── <Project>.sln     # its own solution
│       ├── <Project>/        # the example code
│       └── Tests/            # tests, in most articles
└── .github/workflows/        # PR build: builds and tests changed projects
```

Each article is self-contained. You never need to build the whole repository.

## Contributing

Found a bug in an example, or does a project not build on a newer .NET version? [Open an issue](https://github.com/CodeMazeBlog/CodeMazeGuides/issues) or send a pull request. The PR build checks every changed project automatically.

## Support Code Maze

The blog is free. Our courses keep it that way. If the articles helped you, have a look:

<a href="https://courses.code-maze.com/courses/?source=github"><strong>Browse all Code Maze courses →</strong></a>

A ⭐ on this repository also helps other developers find it.

## License

[MIT](LICENSE). Use the code freely in your own projects.
