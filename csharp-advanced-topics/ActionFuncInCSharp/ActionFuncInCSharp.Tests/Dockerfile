#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
#WORKDIR /app
#
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /src
COPY ["ActionFuncInCSharp.Tests/ActionFuncInCSharp.Tests.csproj", "ActionFuncInCSharp.Tests/"]
COPY ["ActionFuncInCSharp/ActionFuncInCSharp.csproj", "ActionFuncInCSharp/"]
RUN dotnet restore "ActionFuncInCSharp.Tests/ActionFuncInCSharp.Tests.csproj"
COPY . .
WORKDIR "/src/ActionFuncInCSharp.Tests"
RUN dotnet build "ActionFuncInCSharp.Tests.csproj" -c Release -o /app/build

FROM base AS publish
RUN dotnet publish "ActionFuncInCSharp.Tests.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActionFuncInCSharp.Tests.dll"]