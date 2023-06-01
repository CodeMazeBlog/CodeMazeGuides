FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["QueryStrings/QueryStrings.csproj", "QueryStrings/"]
RUN dotnet restore "QueryStrings/QueryStrings.csproj"
COPY . .
WORKDIR "/src/QueryStrings"
RUN dotnet build "QueryStrings.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QueryStrings.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueryStrings.dll"]
